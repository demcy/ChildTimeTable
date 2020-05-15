using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApp.Controllers
{
    [Authorize(Roles = "User")]
    public class ObligationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObligationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        
        public ActionResult ChangeStatus(Guid? id)
        {
            var obligation = _context.Obligations.Single(o => o.Id == id);
            obligation.Status = !obligation.Status;
            _context.SaveChanges();
            return RedirectToAction("Index", "Obligations");
        }

        // GET: Obligations
        public async Task<IActionResult> Index(DateTime dt)
        {
            if (dt == new DateTime())
            {
                dt = DateTime.Today;
            }
            var personId = _context.Persons.Single(p => p.AppUserId == User.UserGuidId()).Id;
            var applicationDbContext = _context.Obligations
                .Where(o=>o.Time.StartTime.Day==dt.Day)
                .Where(o=>o.ParentId==personId || o.ChildId==personId)
                .OrderBy(o=>o.Time.StartTime)
                .Include(o => o.Child)
                .Include(o => o.Location)
                .Include(o => o.Parent)
                .Include(o => o.Time);
            ViewBag.User = personId;
            ViewBag.Data = dt;
            DateTime today = DateTime.Today;
            ViewBag.Today = dt >= today;
            return View(await applicationDbContext.ToListAsync());
        }

        

        // GET: Obligations/Create
        public IActionResult Create(DateTime dt)
        {
            //var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var personId = _context.Persons.Single(p => p.AppUserId == User.UserGuidId()).Id;
            var familyId = _context.Persons.Single(p => p.AppUserId == User.UserGuidId()).FamilyId;
            //ViewData["ChildId"] = new SelectList(_context.Persons, "Id", "Id");
            List<string> fullNames = _context.Persons
                .Where(p=>p.FamilyId==familyId)
                .Select( p => p.FirstName + " " + p.LastName).ToList();
            ViewData["FullName"] = fullNames.Select(x=>new SelectListItem(){Text = x.ToString()});
            //ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            ViewData["LocationValue"] = new SelectList(_context.Locations.Where(l=>l.PersonId==personId), "LocationValue", "LocationValue");
            //ViewData["LocationValue"] = new SelectList(_context.Locations, "LocationValue", "LocationValue");
            ViewData["ParentId"] = new SelectList(_context.Persons, "Id", "Id");
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Id");
            string htmlData = dt.ToString("yyyy-MM-dd") + "T00:00";
            ViewBag.Data = htmlData;
            return View();
        }

        // POST: Obligations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Body,Status,LocationId,TimeId,ObligationType,ParentId,ChildId,CreatedBy,CreatedAt,DeletedBy,DeletedAt,Id")] Obligation obligation, Time time, Location location, string fullName)
        {
            
            var user = _context.Persons.Single(p => p.AppUserId == User.UserGuidId());
            //var personId = _context.Persons.Single(p => p.AppUserId == User.UserGuidId()).Id;
            obligation.ParentId = user.Id;
            ModelState.SetModelValue("ParentId", new ValueProviderResult(user.Id.ToString()));
            var childId = _context.Persons.Single(p => p.FirstName + " " + p.LastName == fullName).Id;
            obligation.ChildId = childId;
            ModelState.SetModelValue("ChildId", new ValueProviderResult(childId.ToString()));
            Time t = new Time();
            t.StartTime = time.StartTime;
            t.EndTime = time.EndTime;
            _context.Add(t);
            _context.SaveChanges();
            obligation.TimeId = t.Id;
            ModelState.SetModelValue("TimeId", new ValueProviderResult(t.Id.ToString()));
            Guid locationId;
            Location l;
            if (_context.Locations.Where(item => item.PersonId == user.Id)
                .Any(item => item.LocationValue == location.LocationValue))
            {
                l = _context.Locations.Where(item => item.PersonId == user.Id)
                    .Single(item => item.LocationValue == location.LocationValue);
                locationId = l.Id;
            }
            else
            {
                l = new Location();
                l.LocationValue = location.LocationValue;
                l.Person = user;
                l.PersonId = user.Id;
                _context.Add(l);
                _context.SaveChanges();
                locationId = l.Id;
            }
            obligation.Location = l;
            obligation.LocationId = locationId;
            ModelState.SetModelValue("LocationId", new ValueProviderResult(locationId.ToString()));
            obligation.Status = false;
            ModelState.SetModelValue("Status", new ValueProviderResult("false"));
            await TryUpdateModelAsync(obligation);
            if (ModelState.IsValid)
            {
                _context.Add(obligation);
                await _context.SaveChangesAsync();
                
                Notification n = new Notification();
                n.SenderId = user.Id;
                n.RecipientId = childId;
                n.Status = false;
                n.Body = user.FirstName + " " + user.LastName + " give you new obligation on " + t.StartTime.ToString("d MMMM");
                _context.Add(n);
                _context.SaveChanges();
                
                return RedirectToAction("Index", "Persons");
                //return RedirectToAction(nameof(Index));
            }
            ViewData["ChildId"] = new SelectList(_context.Persons, "Id", "Id", obligation.ChildId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", obligation.LocationId);
            ViewData["ParentId"] = new SelectList(_context.Persons, "Id", "Id", obligation.ParentId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Id", obligation.TimeId);
            return View(obligation);
        }

        // GET: Obligations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var personId = _context.Persons.Single(p => p.AppUserId == User.UserGuidId()).Id;
            var familyId = _context.Persons.Single(p => p.AppUserId == User.UserGuidId()).FamilyId;
            var obligation = await _context.Obligations.FindAsync(id);
            if (obligation == null)
            {
                return NotFound();
            }
            await _context.Entry(obligation).Reference(i => i.Location).LoadAsync();
            await _context.Entry(obligation).Reference(i => i.Time).LoadAsync();
            await _context.Entry(obligation).Reference(i => i.Child).LoadAsync();
            ViewData["ChildId"] = new SelectList(_context.Persons, "Id", "Id", obligation.ChildId);
            //ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", obligation.LocationId);
            ViewData["LocationValue"] = new SelectList(_context.Locations.Where(l=>l.PersonId==personId), "LocationValue", "LocationValue");
            ViewBag.LValue = obligation.Location.LocationValue;
            List<string> fullNames = _context.Persons
                .Where(p=>p.FamilyId==familyId)
                .Select( p => p.FirstName + " " + p.LastName).ToList();
            ViewData["FullName"] = fullNames.Select(x=>new SelectListItem(){Text = x.ToString()});
            ViewBag.ChildIndex = fullNames.FindIndex(item => item == obligation.Child.FirstName + " " + obligation.Child.LastName);
            //ViewBag.ChildName = obligation.Child.FirstName + " " + obligation.Child.LastName;
            ViewBag.StartTime = obligation.Time.StartTime.ToString("yyyy-MM-ddTHH:mm");
            ViewBag.EndTime = obligation.Time.EndTime.ToString("yyyy-MM-ddTHH:mm");
            ViewData["ParentId"] = new SelectList(_context.Persons, "Id", "Id", obligation.ParentId);
            //ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Id", obligation.TimeId);
            return View(obligation);
        }

        // POST: Obligations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Body,Status,LocationId,TimeId,ObligationType,ParentId,ChildId,CreatedBy,CreatedAt,DeletedBy,DeletedAt,Id,Time,Parent")] Obligation obligation, Time time, Location location, string fullName)
        {
            if (id != obligation.Id)
            {
                return NotFound();
            }
            time.Id =  obligation.TimeId;
            if (obligation.Time.StartTime != time.StartTime || obligation.Time.EndTime != time.EndTime)
            {
                _context.Update(obligation.Time);
                _context.SaveChanges();
            }
            obligation.Time = time;
            
            if (_context.Locations.Where(item => item.PersonId == obligation.ParentId)
                .Any(item => item.LocationValue == location.LocationValue))
            {
                obligation.Location = _context.Locations.Where(item => item.PersonId == obligation.ParentId)
                    .Single(item => item.LocationValue == location.LocationValue);
            }
            else
            {
                Location l = new Location();
                l.LocationValue = location.LocationValue;
                l.Person = obligation.Parent;
                l.PersonId = obligation.ParentId;
                _context.Add(l);
                _context.SaveChanges();
                obligation.Location = l;
            }
            var childId = _context.Persons.Single(p => p.FirstName + " " + p.LastName == fullName).Id;
            obligation.ChildId = childId;
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _context.Update(obligation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChildId"] = new SelectList(_context.Persons, "Id", "Id", obligation.ChildId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", obligation.LocationId);
            ViewData["ParentId"] = new SelectList(_context.Persons, "Id", "Id", obligation.ParentId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Id", obligation.TimeId);
            return View(obligation);
        }

        // GET: Obligations/Delete/5
        /*public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obligation = await _context.Obligations
                .Include(o => o.Child)
                .Include(o => o.Location)
                .Include(o => o.Parent)
                .Include(o => o.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obligation == null)
            {
                return NotFound();
            }

            return View(obligation);
        }*/

        // POST: Obligations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        public async Task<IActionResult> Delete(string id)
        {
            var obligation = await _context.Obligations.FindAsync(id);
            _context.Obligations.Remove(obligation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
