using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace WebHookBot.Services
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
    }
}
