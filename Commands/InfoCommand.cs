using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace WebHookBot.Commands
{
    public class InfoCommand : Command
    {
        public override string Name => "/info";

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(
                chatId: message.Chat,
                text: "👋 Hello! I am a Telegram Bot working on WebHook technology.",
                replyToMessageId: message.MessageId,
                replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                    "Bot code on GitHub",
                    "https://github.com/Ev1ls0n/WebHook-Bot"
                    ))
            );
        }
    }
}
