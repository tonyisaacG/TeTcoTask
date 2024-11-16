namespace CleanArchitectureTask.Application.Interfaces.Services
{
    public interface IMailService
    {
        public void SendMail(string body,string To,string title = null);
    }
}
