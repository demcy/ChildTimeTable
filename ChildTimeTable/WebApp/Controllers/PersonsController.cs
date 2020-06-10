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
    /// <summary>
    /// Main Controller
    /// </summary>
    [Authorize(Roles = "User")]
    public class PersonsController : Controller
    {
        private readonly IAppBLL _bll;
        private readonly IWebHostEnvironment _env;
        /// <summary>
        /// Person Constructor
        /// </summary>
        /// <param name="bll"></param>
        /// <param name="env"></param>
        public PersonsController(IAppBLL bll, IWebHostEnvironment env)
        {
            _bll = bll;
            _env = env;
        }

        /// <summary>
        /// Add person to family
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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
            return RedirectToAction("Index", "Persons");
        }
        /// <summary>
        /// Main Task
        /// </summary>
        /// <returns></returns>
        // GET: Persons
        public async Task<IActionResult> Index()
        {
            var vm = new PersonDataModel();
            vm.DatesList = await _bll.Obligations.DatesList(User.UserGuidId());
            vm.UnreadMessages = (await _bll.Persons.OnePerson(User.UserGuidId())).UnreadMessages;
            //var applicationDbContext = await _bll.Persons.AllFamilyPersons(User.UserGuidId());
            vm.Persons = await _bll.Persons.AllFamilyPersons(User.UserGuidId());
            return View(vm);
        }
        
        /// <summary>
        /// Person Info
        /// </summary>
        /// <returns></returns>
        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit()
        {
            var vm = new PersonModel();
            vm.Person = await _bll.Persons.OnePerson(User.UserGuidId());
            vm.LogoList = _env.WebRootFileProvider.GetDirectoryContents("Icons")
                .Select(item=>item.Name).ToList();
            //var person = await _bll.Persons.OnePerson(User.UserGuidId());
            return View(vm);
        }
        /// <summary>
        /// Redact Person Info
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
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
            return View(vm);
        }

        

        
    }
}
