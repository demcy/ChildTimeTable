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
    [Authorize(Roles = "User")]
    public class NotificationsController : Controller
    {
        private readonly IAppBLL _bll;

        public NotificationsController(IAppBLL bll)
        {
            _bll = bll;
        }


        public async Task<IActionResult> InvitationAccept(string submitButton, Guid id)
        {
            var notification = await _bll.Notifications.FirstOrDefaultAsync(id);
            notification.Status = true;
            await _bll.Notifications.UpdateAsync(notification);
            //await _bll.SaveChangesAsync();
            if (submitButton == "yes")
            {
                //var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var person = await _bll.Persons.OnePerson(User.UserGuidId());
                var sender = await _bll.Persons.FirstOrDefaultAsync(notification.SenderId);
                person.FamilyId = sender.FamilyId;
                await _bll.Persons.UpdateAsync(person);
            }
            
            await _bll.SaveChangesAsync();
            return RedirectToAction("Index", "Persons");
        }
        
        
        
        public async Task<IActionResult> ObligationAccept(Guid id)
        {
            var notification = await _bll.Notifications.FirstOrDefaultAsync(id);
            notification.Status = true;
            await _bll.Notifications.UpdateAsync(notification);
            await _bll.SaveChangesAsync();
            
            
            //var personId = _context.Persons.Single(p => p.AppUserId == User.UserGuidId()).Id;
            //var notification = _context.Notifications.Find(id);
            
            //await _bll.Notifications.UpdateAsync(notification);
            //_context.SaveChanges();
            //var unreadN = _context.Notifications.Count(n => n.RecipientId == personId && n.Status==false);
            //ViewBag.Unread = unreadN;
            if ((await _bll.Notifications.AllImportant(User.UserGuidId()))
                .Count(n => n.Status == false) == 0)
            {
                return RedirectToAction("Index", "Persons");
            }
            return RedirectToAction("Index", "Notifications");
        }
        

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var personId = (await _bll.Persons.OnePerson(User.UserGuidId())).Id;
            var vm = new NotificationDataModel();
            vm.Notifications = await _bll.Notifications.AllImportant(User.UserGuidId());
            vm.UnreadMessages = (await _bll.Notifications.AllImportant(User.UserGuidId()))
                .Count(n => n.Status == false);
            /*var person = _context.Persons.Single(p => p.AppUserId == User.UserGuidId());
            var applicationDbContext = _context.Notifications
                .Include(n => n.Recipient)
                .Where(item=>item.RecipientId == person.Id)
                .Include(n => n.Sender);
            var unreadN = _context.Notifications.Count(n => n.RecipientId == person.Id && n.Status==false);
            ViewBag.Unread = unreadN;*/
            //var applicationDbContext = await _bll.Notifications.AllImportant(User.UserGuidId());
            return View(vm);
        }
    }
}
