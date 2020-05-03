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
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApp.Controllers
{
    public class ObligationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObligationsController(ApplicationDbContext context)
        {
            _context = context;
        }


        public ActionResult ChangeStatus(int id)
        {
            var obligation = _context.Obligations.Single(o => o.ObligationId == id);
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
            var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var personId = _context.Persons.Single(p => p.AppUserId == userId).PersonId;
            var applicationDbContext = _context.Obligations
                .Where(o=>o.Time.StartTime.Day==dt.Day)
                .Where(o=>o.ParentId==personId || o.ChildId==personId)
                .OrderBy(o=>o.Time.StartTime)
                .Include(o => o.Child)
                .Include(o => o.Location)
                .Include(o => o.Parent)
                .Include(o => o.Time);
            ViewBag.User = personId;
            //ViewBag.Data = dt.ToString("d MMMM");
            ViewBag.Data = dt;
            DateTime today = DateTime.Today;
            ViewBag.Today = dt >= today;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Obligations/Details/5
        public async Task<IActionResult> Details(int? id)
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
                .FirstOrDefaultAsync(m => m.ObligationId == id);
            if (obligation == null)
            {
                return NotFound();
            }

            return View(obligation);
        }

        // GET: Obligations/Create
        public IActionResult Create(DateTime dt)
        {
            var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var personId = _context.Persons.Single(p => p.AppUserId == userId).PersonId;
            var familyId = _context.Persons.Single(p => p.AppUserId == userId).FamilyId;
            //ViewData["ChildId"] = new SelectList(_context.Persons, "PersonId", "PersonId");
            List<string> fullNames = _context.Persons
                .Where(p=>p.FamilyId==familyId)
                .Select( p => p.FirstName + " " + p.LastName).ToList();
            ViewData["FullName"] = fullNames.Select(x=>new SelectListItem(){Text = x.ToString()});
            //ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId");
            ViewData["LocationValue"] = new SelectList(_context.Locations.Where(l=>l.PersonId==personId), "LocationValue", "LocationValue");
            //ViewData["LocationValue"] = new SelectList(_context.Locations, "LocationValue", "LocationValue");
            ViewData["ParentId"] = new SelectList(_context.Persons, "PersonId", "PersonId");
            ViewData["TimeId"] = new SelectList(_context.Times, "TimeId", "TimeId");
            string htmlData = dt.ToString("yyyy-MM-dd") + "T00:00";
            ViewBag.Data = htmlData;
            return View();
        }

        // POST: Obligations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObligationId,Body,Status,LocationId,TimeId,ObligationType,ParentId,ChildId")] Obligation obligation, Time time, Location location, string fullName)
        {
            var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var user = _context.Persons.Single(p => p.AppUserId == userId);
            var personId = _context.Persons.Single(p => p.AppUserId == userId).PersonId;
            obligation.ParentId = personId;
            ModelState.SetModelValue("ParentId", new ValueProviderResult(personId.ToString()));
            var childId = _context.Persons.Single(p => p.FirstName + " " + p.LastName == fullName).PersonId;
            obligation.ChildId = childId;
            ModelState.SetModelValue("ChildId", new ValueProviderResult(childId.ToString()));
            Time t = new Time();
            t.StartTime = time.StartTime;
            t.EndTime = time.EndTime;
            _context.Add(t);
            _context.SaveChanges();
            obligation.TimeId = t.TimeId;
            ModelState.SetModelValue("TimeId", new ValueProviderResult(t.TimeId.ToString()));
            int locationId;
            Location l;
            if (_context.Locations.Where(item => item.PersonId == personId)
                .Any(item => item.LocationValue == location.LocationValue))
            {
                l = _context.Locations.Where(item => item.PersonId == personId)
                    .Single(item => item.LocationValue == location.LocationValue);
                locationId = l.LocationId;
            }
            else
            {
                l = new Location();
                l.LocationValue = location.LocationValue;
                l.Person = user;
                l.PersonId = personId;
                _context.Add(l);
                _context.SaveChanges();
                locationId = l.LocationId;
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
                n.SenderId = personId;
                n.RecipientId = childId;
                n.Status = false;
                n.Body = user.FirstName + " " + user.LastName + " give you new obligation on " + t.StartTime.ToString("d MMMM");
                _context.Add(n);
                _context.SaveChanges();
                
                return RedirectToAction("Index", "Persons");
                //return RedirectToAction(nameof(Index));
            }
            //ViewData["ChildId"] = new SelectList(_context.Persons, "PersonId", "PersonId", obligation.ChildId);
            //ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", obligation.LocationId);
            //ViewData["ParentId"] = new SelectList(_context.Persons, "PersonId", "PersonId", obligation.ParentId);
            //ViewData["TimeId"] = new SelectList(_context.Times, "TimeId", "TimeId", obligation.TimeId);
            return View(obligation);
        }

        // GET: Obligations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var personId = _context.Persons.Single(p => p.AppUserId == userId).PersonId;
            var familyId = _context.Persons.Single(p => p.AppUserId == userId).FamilyId;
            var obligation = await _context.Obligations.FindAsync(id);
            
            if (obligation == null)
            {
                return NotFound();
            }
            await _context.Entry(obligation).Reference(i => i.Location).LoadAsync();
            await _context.Entry(obligation).Reference(i => i.Time).LoadAsync();
            await _context.Entry(obligation).Reference(i => i.Child).LoadAsync();
            ViewData["ChildId"] = new SelectList(_context.Persons, "PersonId", "PersonId", obligation.ChildId);
            //ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", obligation.LocationId);
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
            ViewData["ParentId"] = new SelectList(_context.Persons, "PersonId", "PersonId", obligation.ParentId);
            //ViewData["TimeId"] = new SelectList(_context.Times, "TimeId", "TimeId", obligation.TimeId);
            
            return View(obligation);
        }

        // POST: Obligations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("ObligationId,Body,Status,LocationId,TimeId,ObligationType,ParentId,ChildId,Time,Parent")] 
            Obligation obligation, Time time, Location location, string fullName)
        {
            if (id != obligation.ObligationId)
            {
                return NotFound();
            }
            
            if (obligation.Time.StartTime != time.StartTime || obligation.Time.EndTime != time.EndTime)
            {
                _context.Update(obligation.Time);
                _context.SaveChanges();
            }

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
            
            var childId = _context.Persons.Single(p => p.FirstName + " " + p.LastName == fullName).PersonId;
            obligation.ChildId = childId;
            
            
            
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obligation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObligationExists(obligation.ObligationId))
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
            ViewData["ChildId"] = new SelectList(_context.Persons, "PersonId", "PersonId", obligation.ChildId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", obligation.LocationId);
            ViewData["ParentId"] = new SelectList(_context.Persons, "PersonId", "PersonId", obligation.ParentId);
            ViewData["TimeId"] = new SelectList(_context.Times, "TimeId", "TimeId", obligation.TimeId);
            return View(obligation);
        }

        // GET: Obligations/Delete/5
        /*public async Task<IActionResult> Delete(int? id)
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
                .FirstOrDefaultAsync(m => m.ObligationId == id);
            if (obligation == null)
            {
                return NotFound();
            }

            return View(obligation);
        }*/

        // POST: Obligations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        public async Task<IActionResult> Delete(int id)
        {
            var obligation = await _context.Obligations.FindAsync(id);
            _context.Obligations.Remove(obligation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObligationExists(int id)
        {
            return _context.Obligations.Any(e => e.ObligationId == id);
        }
    }
}
