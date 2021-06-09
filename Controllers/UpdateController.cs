/*
 * ===========================================================================================================================
 * Центральным звеном в архитектуре ASP.NET Core MVC является контроллер.
 * При получении запроса система маршрутизации выбирает для обработки запроса нужный контроллер и передает ему данные запроса.
 * Контроллер обрабатывает эти данные и посылает обратно результат обработки.
 * ===========================================================================================================================
 */

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using WebHookBot.Services;

namespace WebHookBot.Controllers
{
    [Route("api/[controller]")] // Атрибуты маршрутизации позволяют не определять дополнительный маршрут, а указать сопоставление прямо в коде контроллера
    [ApiController]
    public class UpdateController : Controller
    {
        // Как и любой класс, контроллер может получать сервисы приложения через механизм dependency injection
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        // POST api/update
        // Объект типа IActionResult предназначен для генерации результата действия
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            await _updateService.EchoAsync(update);
            return Ok(); // OkResult: производный от StatusCodeResult. Возвращает статусный код 200, который уведомляет об успешном выполнении запроса
        }
    }
}
