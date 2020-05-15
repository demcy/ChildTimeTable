using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;


namespace WebApp.Controllers
{
    [Authorize(Roles = "User")]
    public class PersonsController : Controller
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PersonsController(ApplicationDbContext context, IWebHostEnvironment env, IAppUnitOfWork uow)
        {
            _context = context;
            _env = env;
            _uow = uow;
        }

        
        public ActionResult NotificationCreate(string email)
        {
            if (_context.Persons.Any(person => person.AppUser.UserName == email))
            {
                //var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var sender = _context.Persons.Single(p => p.AppUserId == User.UserGuidId());
                string name = sender.FirstName + " " + sender.LastName;
                Notification n = new Notification();
                n.SenderId = sender.Id;
                n.RecipientId = _context.Persons.Single(p => p.AppUser.UserName == email).Id;
                n.Status = false;
                n.Body = name + " invite you to his/her family";
                _context.Add(n);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Persons");
        }
        
        // GET: Persons
        public async Task<IActionResult> Index()
        {
            var person = _context.Persons.Single(p => p.AppUserId == User.UserGuidId());
            var unreadN = _context.Notifications.Count(n => n.RecipientId == person.Id && n.Status==false);
            var applicationDbContext = _context.Persons
                .Include(p => p.AppUser)
                .Where(item=>item.FamilyId==person.FamilyId)
                .Include(p => p.Family);
            List<DateTime> dates = _context.Obligations.Where(o=>o.ParentId==person.Id || o.ChildId==person.Id)
                .Select(o => o.Time).Select(t => t.StartTime).ToList();
            ViewData["Dates"] = dates;
            ViewBag.Unread = unreadN;
            return View(await applicationDbContext.ToListAsync());
        }
        
        
        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit()
        {
            var personId = _context.Persons.Single(p => p.AppUserId == User.UserGuidId()).Id;
            var person =  await _context.Persons.FindAsync(personId);
            List<string> logos = _env.WebRootFileProvider.GetDirectoryContents("Icons")
                .Select(item=>item.Name).ToList();
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", person.AppUserId);
            ViewData["FamilyId"] = new SelectList(_context.Families, "Id", "Id", person.FamilyId);
            ViewBag.Logo = person.Logo;
            ViewData["Logos"] = logos;
            return View(person);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("FirstName,LastName,Logo,AppUserId,FamilyId,PersonType,CreatedBy,CreatedAt,DeletedBy,DeletedAt,Id")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Update(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", person.AppUserId);
            ViewData["FamilyId"] = new SelectList(_context.Families, "Id", "Id", person.FamilyId);
            return View(person);
        }

        

        
    }
}
