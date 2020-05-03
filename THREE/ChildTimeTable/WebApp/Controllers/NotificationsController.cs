using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public ActionResult InvitationAccept(string submitButton, int? id)
        {
            var notification = _context.Notifications.Find(id);
            notification.Status = true;
            if (submitButton == "yes")
            {
                var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var person = _context.Persons.Single(p => p.AppUserId == userId);
                var sender = _context.Persons.Find(notification.SenderId);
                person.FamilyId = sender.FamilyId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Persons");
        }
        
        public ActionResult ObligationAccept(int? id)
        {
            var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var personId = _context.Persons.Single(p => p.AppUserId == userId).PersonId;
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
        
        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var person = _context.Persons.Single(p => p.AppUserId == userId);
            var applicationDbContext = _context.Notifications
                .Include(n => n.Recipient)
                .Where(item=>item.RecipientId == person.PersonId)
                .Include(n => n.Sender);
            var unreadN = _context.Notifications.Count(n => n.RecipientId == person.PersonId && n.Status==false);
            ViewBag.Unread = unreadN;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(n => n.Recipient)
                .Include(n => n.Sender)
                .FirstOrDefaultAsync(m => m.NotificationId == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            ViewData["RecipientId"] = new SelectList(_context.Persons, "PersonId", "PersonId");
            ViewData["SenderId"] = new SelectList(_context.Persons, "PersonId", "PersonId");
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotificationId,Body,Status,SenderId,RecipientId")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipientId"] = new SelectList(_context.Persons, "PersonId", "PersonId", notification.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Persons, "PersonId", "PersonId", notification.SenderId);
            return View(notification);
        }

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            ViewData["RecipientId"] = new SelectList(_context.Persons, "PersonId", "PersonId", notification.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Persons, "PersonId", "PersonId", notification.SenderId);
            return View(notification);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotificationId,Body,Status,SenderId,RecipientId")] Notification notification)
        {
            if (id != notification.NotificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notification.NotificationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipientId"] = new SelectList(_context.Persons, "PersonId", "PersonId", notification.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Persons, "PersonId", "PersonId", notification.SenderId);
            return View(notification);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(n => n.Recipient)
                .Include(n => n.Sender)
                .FirstOrDefaultAsync(m => m.NotificationId == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(int id)
        {
            return _context.Notifications.Any(e => e.NotificationId == id);
        }
    }
}
