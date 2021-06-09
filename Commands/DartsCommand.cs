using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace WebHookBot.Commands
{
    public class DartsCommand : Command
    {
        public override string Name => "/darts";

        private readonly ILogger logger;

        public DartsCommand()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
            });

            logger = loggerFactory.CreateLogger<DartsCommand>();
        }

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            Message msg = await client.SendDiceAsync(
                chatId: message.Chat,
                emoji: Emoji.Darts,
                replyToMessageId: message.MessageId,
                replyMarkup: new InlineKeyboardMarkup(new[] { new[] { InlineKeyboardButton.WithCallbackData("Delete message", "delete_msg") } })
            );

            logger.LogInformation($"(i) Darts result: {msg.Dice.Value}");
        }
    }
}
