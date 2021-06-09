using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WebHookBot.Services
{
    public class MessageUpdateService : IUpdateService
    {
        private readonly IBotService _botService;
        private readonly ICallbackService _callbackService;
        private readonly ILogger<MessageUpdateService> _logger;

        public MessageUpdateService(IBotService botService, ICallbackService callbackService, ILogger<MessageUpdateService> logger)
        {
            _botService = botService;
            _callbackService = callbackService;
            _logger = logger;
        }

        // Метод, который принимает обновления от бота (сервера) и обрабатывает их
        public async Task EchoAsync(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                await _callbackService.BotOnCallbackQueryReceived(_botService.Client, update.CallbackQuery);
                return;
            }

            // Данное условие не пропускает обновления, которые не являются сообщениями от пользователя
            if (update.Type != UpdateType.Message)
                return;

            var message = update.Message;

            _logger.LogInformation($"(i) Received Message from {message.Chat.Id}");

            // Поиск введенной пользователем команды, среди существующих у бота команд
            foreach (var command in _botService.Commands)
            {
                if (command.Contains(message.Text))
                {
                    await command.Execute(message, _botService.Client);
                    break;
                }
            }
        }
    }
}
