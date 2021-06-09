using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WebHookBot.Services
{
    public class CallbackService : ICallbackService
    {
        public async Task BotOnCallbackQueryReceived(TelegramBotClient client, CallbackQuery callbackQuery)
        {
            switch (callbackQuery.Data)
            {
                case "delete_msg":
                    // Если сообщение находится в личной переписке - бот не может его удалить
                    // У личной переписки свойство Title равно null
                    if (callbackQuery.Message.Chat.Title == null)
                    {
                        await client.AnswerCallbackQueryAsync(
                            callbackQueryId: callbackQuery.Id,
                            text: "⚠️ Bot can't delete messages in private chat."
                        );
                    }
                    else
                    {
                        await client.DeleteMessageAsync(
                            chatId: callbackQuery.Message.Chat,
                            messageId: callbackQuery.Message.MessageId
                        );
                    }
                    break;
            }
        }
    }
}
