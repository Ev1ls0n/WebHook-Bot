using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace WebHookBot.Commands
{
    public class DiceCommand : Command
    {
        public override string Name => "/dice";

        private readonly ILogger logger;

        public DiceCommand()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
            });

            logger = loggerFactory.CreateLogger<DiceCommand>();
        }

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            Message msg = await client.SendDiceAsync(
                chatId: message.Chat,
                emoji: Emoji.Dice,
                replyToMessageId: message.MessageId,
                replyMarkup: new InlineKeyboardMarkup(new[] { new[] { InlineKeyboardButton.WithCallbackData("Delete message", "delete_msg") } })
            );

            logger.LogInformation($"(i) Dice result: {msg.Dice.Value}");
        }
    }
}
