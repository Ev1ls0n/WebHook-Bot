using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WebHookBot.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract Task Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {
            if (!command.Contains("ew_webhook_bot"))
                return command.Contains(this.Name);
            else
                return command.Contains(this.Name) && command.Contains("ew_webhook_bot");
        }
    }
}
