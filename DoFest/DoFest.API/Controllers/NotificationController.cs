﻿using System;
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
    public sealed class NotificationController: ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAllNotificationsUser()
        {
            var result = await _notificationService.FindAllNotifications();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationModel notificationModel)
        {
            var (_, isFailure, value, error) = await _notificationService.CreateNotification(notificationModel);
            if (isFailure)
            {
                return BadRequest(error);
            }

            return Created(value.Id.ToString(),null);
        }
    }
}