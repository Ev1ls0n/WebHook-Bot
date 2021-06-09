using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Telegram.Bot;

using WebHookBot.Commands;

namespace WebHookBot.Services
{
    public class BotService : IBotService
    {
        private List<Command> CommandsList; // Список подключенных команд бота
        public IReadOnlyList<Command> Commands { get => CommandsList.AsReadOnly(); } // Делает список команд доступным только для чтения

        private readonly BotConfiguration _config;

        // С помощью объекта IOptions можно передавать конфигурацию не просто как набор настроек в виде пар ключ-значение,
        // а как объекты определенных классов.
        public BotService(IOptions<BotConfiguration> config)
        {
            _config = config.Value;
            Client = new TelegramBotClient(_config.BotToken);

            // Инициализация списка команд и самих команд
            CommandsList = new List<Command>();

            CommandsList.Add(new HelpCommand());
            CommandsList.Add(new InfoCommand());
            CommandsList.Add(new DiceCommand());
            CommandsList.Add(new DartsCommand());
            // ---
        }

        public TelegramBotClient Client { get; } // Свойство, которое хранит объект клиента бота
    }
}
