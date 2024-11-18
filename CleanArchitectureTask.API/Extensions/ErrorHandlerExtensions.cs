using CleanArchitectureTask.Application.Commons.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace CleanArchitectureTask.API.Extensions
{
    public static class ErrorHandlerExtensions
    {
        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if( contextFeature == null ) return;
                    context.Response.Headers.Add("Access-Control-Allow-Origin","*");
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        BadRequestException => (int)HttpStatusCode.BadRequest,
                        OperationCanceledException => (int)HttpStatusCode.ServiceUnavailable,
                        NotFoundException => (int)HttpStatusCode.NotFound,
                        _ => (int)HttpStatusCode.InternalServerError
                    };
                    var errorResponse = new Application.Commons.Dtos.Result<object>()
                    {
                        Code = context.Response.StatusCode,
                        Succeeded = false
                    };
                    var validationError = ( contextFeature.Error as BaseRequestException );
                    try
                    {
                        if( validationError != null && validationError.ValidationResults != null && validationError.ValidationResults.Count() > 0 )
                        { errorResponse.ValidationErrors = validationError.ValidationResults.ToList(); }
                        else
                        { errorResponse.Messages.Add(contextFeature.Error.GetBaseException().Message); }
                    } catch( Exception ex ) { errorResponse.Messages = new List<string> { "Internal Server Error." }; }
                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                });
            });
        }
    }
}
