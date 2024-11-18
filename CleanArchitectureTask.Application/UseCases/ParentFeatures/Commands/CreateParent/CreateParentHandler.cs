using AutoMapper;
using CleanArchitectureTask.Application.Commons.Exceptions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.Interfaces.Services;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.Commons;
using CleanArchitectureTask.Domain.Entities;
using MediatR;
using System.IO;
using System.Reflection;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent
{
    public sealed class CreateParentHandler : IRequestHandler<CreateParentRequest,ParentResponseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IFileProvider _fileProvider;
        public CreateParentHandler(IUnitOfWork unitOfWork,IMapper mapper,IMailService mailService,IFileProvider fileProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mailService = mailService;
            _fileProvider = fileProvider;
        }
        public async Task<ParentResponseCommand> Handle(CreateParentRequest request,CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.CreateTransactionAsync();
                var existParent = await _unitOfWork.GetRepository<IParentRepository>().FindParentByNationalIdOrPhoneNum(request.NationalId,request.PhoneNumber);
                if( existParent != null )
                {
                    throw new NotFoundException("Can't Create Parent With The Same Phone Or NationalId");
                }
                var parent = _mapper.Map<Parent>(request);
                await _unitOfWork.GetRepository<IParentRepository>().Create(parent);
                await _unitOfWork.SaveAsync(cancellationToken);
                await _unitOfWork.GetRepository<IParentWalletRepository>().Create(new ParentWallet { OwnerId = parent.Id,Balance = request.WalletBalance });
                await _unitOfWork.SaveAsync(cancellationToken);
                await _unitOfWork.CommitAsync();


                string templatePath =   _fileProvider.GetHtmlTemplatePath("Wellcome.html");
                var parameters = new Dictionary<string,string> {{ "Username",$"{parent.NameEn}" }};
                string emailBody = LoadAndRenderTemplate(templatePath,parameters);
                _mailService.SendMail(emailBody,parent.Email,"Create Wallet For You");
                return _mapper.Map<ParentResponseCommand>(parent);
            }
            catch( Exception ex )
            {
                await _unitOfWork.RollbackAsync();
                throw ex;
            }
        }

        public string LoadAndRenderTemplate(string templatePath,Dictionary<string,string> parameters)
        {
            string templateContent = System.IO.File.ReadAllText(templatePath);
            foreach( var parameter in parameters )
            {
                templateContent = templateContent.Replace($"{{{parameter.Key}}}",parameter.Value);
            }
            return templateContent;
        }
    }
}
