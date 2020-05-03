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
using Microsoft.AspNetCore.Hosting;

namespace WebApp.Controllers
{
    public class PersonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PersonsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        
        public ActionResult NotificationCreate(string email)
        {
            if (_context.Persons.Any(person => person.AppUser.UserName == email))
            {
                var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var sender = _context.Persons.Single(p => p.AppUserId == userId);
                string name = sender.FirstName + " " + sender.LastName;
                Notification n = new Notification();
                n.SenderId = sender.PersonId;
                n.RecipientId = _context.Persons.Single(p => p.AppUser.UserName == email).PersonId;
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
            var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var person = _context.Persons.Single(p => p.AppUserId == userId);
            var personId = _context.Persons.Single(p => p.AppUserId == userId).PersonId;
            var unreadN = _context.Notifications.Count(n => n.RecipientId == personId && n.Status==false);
            var applicationDbContext = _context.Persons
                .Include(p => p.AppUser)
                .Where(item=>item.FamilyId==person.FamilyId)
                .Include(p => p.Family);
            List<DateTime> dates = _context.Obligations.Where(o=>o.ParentId==person.PersonId || o.ChildId==person.PersonId)
                .Select(o => o.Time).Select(t => t.StartTime).ToList();
            ViewData["Dates"] = dates;
            ViewBag.Unread = unreadN;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Persons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.AppUser)
                .Include(p => p.Family)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyId");
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FirstName,LastName,Logo,AppUserId,FamilyId,PersonType")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", person.AppUserId);
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyId", person.FamilyId);
            return View(person);
        }

        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit()
        {
            var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var personId = _context.Persons.Single(p => p.AppUserId == userId).PersonId;
            var person =  await _context.Persons.FindAsync(personId);
            List<string> logos = _env.WebRootFileProvider.GetDirectoryContents("Icons")
                .Select(item=>item.Name).ToList();
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", person.AppUserId);
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyId", person.FamilyId);
            ViewBag.Logo = person.Logo;
            ViewData["Logos"] = logos;
            return View(person);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("PersonId,FirstName,LastName,Logo,AppUserId,FamilyId,PersonType")] Person person)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", person.AppUserId);
            ViewData["FamilyId"] = new SelectList(_context.Families, "FamilyId", "FamilyId", person.FamilyId);
            return View(person);
        }

        // GET: Persons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.AppUser)
                .Include(p => p.Family)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.PersonId == id);
        }
    }
}
