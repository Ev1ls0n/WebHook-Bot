using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WebHookBot.Services
{
    public interface ICallbackService
    {
        Task BotOnCallbackQueryReceived(TelegramBotClient client, CallbackQuery callbackQuery);
    }
}
