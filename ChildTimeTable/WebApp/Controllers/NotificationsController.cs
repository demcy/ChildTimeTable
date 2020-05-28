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

/*
        public ActionResult InvitationAccept(string submitButton, Guid? id)
        {
            var notification = _context.Notifications.Find(id);
            notification.Status = true;
            if (submitButton == "yes")
            {
                //var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var person = _context.Persons.Single(p => p.AppUserId == User.UserGuidId());
                var sender = _context.Persons.Find(notification.SenderId);
                person.FamilyId = sender.FamilyId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Persons");
        }
        
        public ActionResult ObligationAccept(Guid? id)
        {
            var personId = _context.Persons.Single(p => p.AppUserId == User.UserGuidId()).Id;
            var notification = _context.Notifications.Find(id);
            notification.Status = true;
            _context.SaveChanges();
            var unreadN = _context.Notifications.Count(n => n.RecipientId == personId && n.Status==false);
            ViewBag.Unread = unreadN;
            if (unreadN == 0)
            {
                return RedirectToAction("Index", "Persons");
            }
            return RedirectToAction("Index", "Notifications");
        }
        */

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            /*var person = _context.Persons.Single(p => p.AppUserId == User.UserGuidId());
            var applicationDbContext = _context.Notifications
                .Include(n => n.Recipient)
                .Where(item=>item.RecipientId == person.Id)
                .Include(n => n.Sender);
            var unreadN = _context.Notifications.Count(n => n.RecipientId == person.Id && n.Status==false);
            ViewBag.Unread = unreadN;*/
            var applicationDbContext = await _bll.Notifications.AllImportant(User.UserGuidId());
            return View(applicationDbContext);
        }
    }
}
