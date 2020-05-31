using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using WebApp.Models;


namespace WebApp.Controllers
{
    [Authorize(Roles = "User")]
    public class PersonsController : Controller
    {
        private readonly IAppBLL _bll;
        private readonly IWebHostEnvironment _env;

        public PersonsController(IAppBLL bll, IWebHostEnvironment env)
        {
            _bll = bll;
            _env = env;
        }


        public async Task<IActionResult> NotificationCreate(string email)
        {
            if (await _bll.Persons.ExistAny(email))
            {
                var sender = await _bll.Persons.OnePerson(User.UserGuidId());
                string name = sender.FirstName + " " + sender.LastName;
                Notification n = new Notification();
                n.SenderId = sender.Id;
                n.RecipientId = (await _bll.Persons.RecipientPerson(email)).Id;
                n.Status = false;
                n.Body = name + " invite you to his/her family";
                _bll.Notifications.Add(n);
                await _bll.SaveChangesAsync();
            }
            /*if (_context.Persons.Any(person => person.AppUser.UserName == email))
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
            }*/
            return RedirectToAction("Index", "Persons");
        }
        
        // GET: Persons
        public async Task<IActionResult> Index()
        {
            /*var person = _context.Persons.Single(p => p.AppUserId == User.UserGuidId());
            var unreadN = _context.Notifications.Count(n => n.RecipientId == person.Id && n.Status==false);
            var applicationDbContext = _context.Persons
                .Include(p => p.AppUser)
                .Where(item=>item.FamilyId==person.FamilyId)
                .Include(p => p.Family);
            List<DateTime> dates = _context.Obligations.Where(o=>o.ParentId==person.Id || o.ChildId==person.Id)
                .Select(o => o.Time).Select(t => t.StartTime).ToList();
            ViewData["Dates"] = dates;
            ViewBag.Unread = unreadN;
            return View(await applicationDbContext.ToListAsync());*/
            var vm = new PersonDataModel();
            vm.DatesList = await _bll.Obligations.DatesList(User.UserGuidId());
            vm.UnreadMessages = (await _bll.Persons.OnePerson(User.UserGuidId())).UnreadMessages;
            //var applicationDbContext = await _bll.Persons.AllFamilyPersons(User.UserGuidId());
            vm.Persons = await _bll.Persons.AllFamilyPersons(User.UserGuidId());
            return View(vm);
        }
        
        
        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit()
        {
            /*var personId = _context.Persons.Single(p => p.AppUserId == User.UserGuidId()).Id;
            var person =  await _context.Persons.FindAsync(personId);
            List<string> logos = _env.WebRootFileProvider.GetDirectoryContents("Icons")
                .Select(item=>item.Name).ToList();
            var vm = new PersonModel();
            vm.AppUserIdSelectList = new SelectList(_context.Users, nameof(Person.Id), "Id", person.AppUserId);
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", person.AppUserId);
            ViewData["FamilyId"] = new SelectList(_context.Families, "Id", "Id", person.FamilyId);
            ViewBag.Logo = person.Logo;
            ViewData["Logos"] = logos;*/
            var vm = new PersonModel();
            vm.Person = await _bll.Persons.OnePerson(User.UserGuidId());
            vm.LogoList = _env.WebRootFileProvider.GetDirectoryContents("Icons")
                .Select(item=>item.Name).ToList();
            //var person = await _bll.Persons.OnePerson(User.UserGuidId());
            return View(vm);
            
        }
        
        // POST: Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.Persons.UpdateAsync(vm.Person);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", person.AppUserId);
            //ViewData["FamilyId"] = new SelectList(_context.Families, "Id", "Id", person.FamilyId);
            return View(vm);
        }

        

        
    }
}
