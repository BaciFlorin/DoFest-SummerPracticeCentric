using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Identity.Models.Notifications;
using DoFest.Business.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("api/v1/notifications")]
    [ApiController]
    [Authorize]
    public sealed class NotificationsController: ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAllNotificationsUser()
        {
            var result = await _notificationService.FindAllNotifications();
            return Ok(result);
        }
    }
}