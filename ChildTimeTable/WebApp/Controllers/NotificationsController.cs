using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using WebApp.Models;

namespace WebApp.Controllers
{
    /// <summary>
    /// Notification Control
    /// </summary>
    [Authorize(Roles = "User")]
    public class NotificationsController : Controller
    {
        private readonly IAppBLL _bll;
        /// <summary>
        /// Notification Constructor
        /// </summary>
        /// <param name="bll"></param>
        public NotificationsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Accept of invitation to family
        /// </summary>
        /// <param name="submitButton"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> InvitationAccept(string submitButton, Guid id)
        {
            var notification = await _bll.Notifications.FirstOrDefaultAsync(id);
            notification.Status = true;
            await _bll.Notifications.UpdateAsync(notification);
            if (submitButton == "yes")
            {
                var person = await _bll.Persons.OnePerson(User.UserId());
                var sender = await _bll.Persons.FirstOrDefaultAsync(notification.SenderId);
                person.FamilyId = sender.FamilyId;
                await _bll.Persons.UpdateAsync(person);
            }
            await _bll.SaveChangesAsync();
            return RedirectToAction("Index", "Persons");
        }
        
        
        /// <summary>
        /// Read obligation request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ObligationAccept(Guid id)
        {
            var notification = await _bll.Notifications.FirstOrDefaultAsync(id);
            notification.Status = true;
            await _bll.Notifications.UpdateAsync(notification);
            await _bll.SaveChangesAsync();
            if ((await _bll.Notifications.AllImportant(User.UserId()))
                .Count(n => n.Status == false) == 0)
            {
                return RedirectToAction("Index", "Persons");
            }
            return RedirectToAction("Index", "Notifications");
        }
        
        /// <summary>
        /// All Person Notifications
        /// </summary>
        /// <returns></returns>
        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var vm = new NotificationDataModel();
            vm.Notifications = await _bll.Notifications.AllImportant(User.UserId());
            vm.UnreadMessages = (await _bll.Notifications.AllImportant(User.UserId()))
                .Count(n => n.Status == false);
            return View(vm);
        }
    }
}
