using System.Collections.Generic;
using Telegram.Bot;
using WebHookBot.Commands;

namespace WebHookBot.Services
{
    public interface IBotService
    {
        IReadOnlyList<Command> Commands { get => new List<Command>().AsReadOnly(); }

        TelegramBotClient Client { get; }
    }
}
