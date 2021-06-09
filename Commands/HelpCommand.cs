using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WebHookBot.Commands
{
    public class HelpCommand : Command
    {
        public override string Name => "/help";

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            string msg = "" +
                "<code>/help</code> - Get a list of available commands 📄\n" +
                "<code>/info</code> - Bot information ℹ️\n" +
                "<code>/dice</code> - Roll a dice! 🎲\n" +
                "<code>/darts</code> - Play darts 🎯";

            await client.SendTextMessageAsync(
                chatId: message.Chat,
                text: msg,
                parseMode: ParseMode.Html,
                replyToMessageId: message.MessageId
            );
        }
    }
}
