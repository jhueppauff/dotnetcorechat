using System.Threading.Tasks;

namespace dotnetcorechat.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}