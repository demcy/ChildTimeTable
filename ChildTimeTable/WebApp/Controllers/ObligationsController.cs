using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApp.Models;

namespace WebApp.Controllers
{
    /// <summary>
    /// Obligations Control
    /// </summary>
    [Authorize(Roles = "User")]
    public class ObligationsController : Controller
    {
        private readonly IAppBLL _bll;
        

        /// <summary>
        /// BLL DataBase
        /// </summary>
        /// <param name="bll"></param>
        public ObligationsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Status Slider Implimentation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ChangeStatus(Guid id)
        {
            var obligation = await _bll.Obligations.FirstOrDefaultAsync(id);
            obligation.Status = !obligation.Status;
            await _bll.Obligations.UpdateAsync(obligation);
            await _bll.SaveChangesAsync();
            return RedirectToAction("Index", "Obligations");
        }
        /// <summary>
        /// List of day's Obligations
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        // GET: Obligations
        public async Task<IActionResult> Index(DateTime dt)
        {
            if (dt == new DateTime())
            {
                dt = DateTime.Today;
            }
            var vm = new ObligationDataModel();
            vm.Obligations = await _bll.Obligations.AllPerDay(dt, User.UserGuidId());
            vm.Date = dt;
            vm.HtmlDate = dt.ToString("yyyy-MM-dd");
            DateTime today = DateTime.Today;
            vm.Today = dt >= today;
            vm.PersonId = (await _bll.Persons.OnePerson(User.UserGuidId())).Id;
            return View(vm);
        }

        
        /// <summary>
        /// Create one
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        // GET: Obligations/Create
        public async Task<IActionResult> Create(DateTime dt)
        {
            var vm = new ObligationModel();
            vm.StartTime = dt.ToString("yyyy-MM-ddTHH:mm");
            vm.EndTime = dt.ToString("yyyy-MM-ddTHH:mm");
            vm.LocationValues = new SelectList(await _bll.Locations.AllForPerson(User.UserGuidId()),
                nameof(Location.LocationValue),
                nameof(Location.LocationValue));
            List<string> fullNames = (await _bll.Persons.AllFamilyPersons(User.UserGuidId()))
                .Select( p => p.FirstName + " " + p.LastName).ToList();
            vm.FullNames = fullNames.Select(x=>new SelectListItem(){Text = x.ToString()});
            return View(vm);
        }
        /// <summary>
        /// POST Create
        /// </summary>
        /// <param name="obligation"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        // POST: Obligations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Obligation obligation, string fullName)
        {
            var user = await _bll.Persons.OnePerson(User.UserGuidId());
            obligation.ParentId = user.Id;
            ModelState.SetModelValue("ParentId", new ValueProviderResult(user.Id.ToString()));
            var child = await _bll.Persons.PersonByName(fullName);
            obligation.ChildId = child.Id;
            ModelState.SetModelValue("ChildId", new ValueProviderResult(child.Id.ToString()));
            Time t = new Time();
            t.StartTime = obligation.Time!.StartTime;
            t.EndTime = obligation.Time!.EndTime;
            _bll.Times.Add(t);
            await _bll.SaveChangesAsync();
            obligation.TimeId = t.Id;
            ModelState.SetModelValue("TimeId", new ValueProviderResult(t.Id.ToString()));
            Location l;    
            if (await _bll.Locations.ExistsValue(obligation.Location!.LocationValue, User.UserGuidId()))
            {
                l = await _bll.Locations.LocationByValue(obligation.Location.LocationValue, User.UserGuidId());
            }
            else
            {
                l = new Location();
                l.LocationValue = obligation.Location.LocationValue;
                l.PersonId = user.Id;
                _bll.Locations.Add(l);
                await _bll.SaveChangesAsync();
            }
            obligation.LocationId = l.Id;
            ModelState.SetModelValue("LocationId", new ValueProviderResult(l.Id.ToString()));
            obligation.Status = false;
            ModelState.SetModelValue("Status", new ValueProviderResult("false"));
            TryValidateModel(true);
            //await TryUpdateModelAsync(obligation);
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _bll.Obligations.Add(obligation);
                await _bll.SaveChangesAsync();
                Notification n = new Notification();
                n.SenderId = user.Id;
                n.RecipientId = child.Id;
                n.Status = false;
                n.Body = user.FirstName + " " + user.LastName + " give you new obligation on " + t.StartTime.ToString("d MMMM");
                _bll.Notifications.Add(n);
                await _bll.SaveChangesAsync();
                return RedirectToAction("Index", "Persons");
            }
            var vm = new ObligationModel();
            vm.Obligation = obligation;
            return View(vm);
        }
        /// <summary>
        /// Edit by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Obligations/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obligation = await _bll.Obligations.EditOne(id);
            var vm = new ObligationModel();
            vm.Obligation = obligation;
            vm.StartTime = obligation.Time!.StartTime.ToString("yyyy-MM-ddTHH:mm");
            vm.EndTime = obligation.Time.EndTime.ToString("yyyy-MM-ddTHH:mm");
            vm.LocationValue = obligation.Location!.LocationValue;
            vm.LocationValues = new SelectList(await _bll.Locations.AllForPerson(User.UserGuidId()),
                nameof(BLL.App.DTO.Location.LocationValue),
                nameof(BLL.App.DTO.Location.LocationValue));
            List<string> fullNames = (await _bll.Persons.AllFamilyPersons(User.UserGuidId()))
                .Select( p => p.FirstName + " " + p.LastName).ToList();
            vm.FullNames = fullNames.Select(x=>new SelectListItem(){Text = x.ToString()});
            vm.ChildIndex = fullNames.FindIndex(item => item == obligation.Child!.FirstName + " " + obligation.Child.LastName);
            return View(vm);
            /*
            await _context.Entry(obligation).Reference(i => i.Location).LoadAsync();
            await _context.Entry(obligation).Reference(i => i.Time).LoadAsync();
            await _context.Entry(obligation).Reference(i => i.Child).LoadAsync();
            */
        }
        /// <summary>
        /// POST Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obligation"></param>
        /// <param name="time"></param>
        /// <param name="location"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        // POST: Obligations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, Obligation obligation, string fullName)
        {
            var user = await _bll.Persons.OnePerson(User.UserGuidId());
            Time t = await _bll.Times.FirstOrDefaultAsync(obligation.TimeId);
            if (obligation.Time!.StartTime != t.StartTime || obligation.Time.EndTime != t.EndTime)
            {
                t.StartTime = obligation.Time.StartTime;
                t.EndTime = obligation.Time.EndTime;
                await _bll.Times.UpdateAsync(t);
                await _bll.SaveChangesAsync();
            }
            Location l;    
            if (await _bll.Locations.ExistsValue(obligation.Location!.LocationValue, User.UserGuidId()))
            {
                l = await _bll.Locations.LocationByValue(obligation.Location.LocationValue, User.UserGuidId());
            }
            else
            {
                l = new Location();
                l.LocationValue = obligation.Location.LocationValue;
                l.PersonId = user.Id;
                _bll.Locations.Add(l);
                await _bll.SaveChangesAsync();
            }
            obligation.LocationId = l.Id;
            var childId = (await _bll.Persons.PersonByName(fullName)).Id;
            obligation.ChildId = childId;
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                await _bll.Obligations.UpdateAsync(obligation);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var vm = new ObligationModel();
            vm.Obligation = obligation;
            return View(vm);
        }

        

        
        /// <summary>
        /// DELETE NO ASK
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bll.Obligations.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
