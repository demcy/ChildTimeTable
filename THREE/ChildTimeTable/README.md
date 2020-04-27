dotnet ef migrations add InitialDbCreation --project WebApp3 --startup-project WebApp3
dotnet ef database update --project WebApp3 --startup-project WebApp3
dotnet ef database drop --project WebApp3 --startup-project WebApp3

dotnet ef migrations add InitialDbCreation --project DAL.App.EF --startup-project WebApp
dotnet ef database update --project DAL.App.EF --startup-project WebApp
dotnet ef database drop --project DAL.App.EF --startup-project WebApp

dotnet aspnet-codegenerator controller -name NotificationsController          -actions -m Notification          -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name PersonsController          -actions -m Person          -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name FamiliesController       -actions -m Family        -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name ObligationsController          -actions -m Obligation          -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name LocationsController   -actions -m Location   -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name TimesController   -actions -m Time   -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f


dotnet aspnet-codegenerator controller -name PersonsController -actions -m Person -dc ApplicationDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name ContactsController -actions -m Contact -dc ApplicationDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name ContactTypesController -actions -m ContactType -dc ApplicationDbContext -outDir ApiControllers -api --useAsyncActions  -f

public async Task<IActionResult> Index()
        {
            var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
            
            var applicationDbContext = _context.Persons
                .Include(p => p.IdentityUser)
                .Where(p=>p.IdentityUserId == userId);
            return View(await applicationDbContext.ToListAsync());
        }
        
asp-items="@Html.GetEnumSelectList<PersonType>()"

@if (SignInManager.IsSignedIn(User))
[Authorize]
[AllowAnonymous]
                        

dotnet aspnet-codegenerator identity -dc DAL.App.EF.ApplicationDbContext  -f

dotnet aspnet-codegenerator identity -dc WebApp3.Data.ApplicationDbContext -f
dotnet aspnet-codegenerator identity -dc DAL.App.EF.ApplicationDbContext -u Domain.Identity.AppUser -f -udui
 -sqlite


~~~Person
public ActionResult NotificationCreate(string email)
        {
            if (_context.Persons.Any(p => p.AppUser.UserName == email))
            {
                int secondId = _context.Persons.Single(p => p.AppUser.UserName == email).PersonId;
                var userId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var p = _context.Persons.Single(p => p.AppUserId == userId);
                int firstId = p.PersonId;
                string name = p.FirstName + " " + p.LastName;
                Notification n = new Notification();
                n.ParentId = firstId;
                n.ChildId = secondId;
                n.Status = false;
                n.Body = name + " invite you to his/her family";
                _context.Add(n);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Persons");
        }
        
        @using(Html.BeginForm("NotificationCreate", "Persons"))
            {
                <div class="form-group">
                    <label class="control-label">Email</label>
                    <input name="email" class ="form-control"/>
                </div>
                <div class="form-group">
                    <input type="submit" class="btn btn-primary"/>
                </div>
                
            }
~~~

~~~Notification
public ActionResult InvitationAccept(string submitButton, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = _context.Notifications.Find(id);
            if (notification == null)
            {
                return NotFound();
            }

            notification.Status = true;
            if (submitButton == "yes")
            {
                string appUserId = User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
                Person person = _context.Persons.Single(p => p.AppUserId == appUserId);
                var parentPerson = _context.Persons.Find(notification.ParentId);
                person.FamilyId = parentPerson.FamilyId;
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Notifications");
        }

@using (Html.BeginForm("InvitationAccept", "Notifications"))
                {
                    <input type="submit" name="submitbutton" value="yes" class="btn btn-primary"/>
                    <input type="submit" name="submitbutton" value="no" class="btn btn-primary"/>
                    <input type="hidden" name="id" value="@item.NotificationId"/>
                }


~~~
~~~REGISTER
if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                Family f = new Family();
                _context.Add(f);
                _context.SaveChanges();
                List<string> logos = _env.WebRootFileProvider.GetDirectoryContents("Icons")
                    .Select(item=>item.Name).ToList();
                Random rnd = new Random();
                string logo = logos[rnd.Next(logos.Count)];
                Person p = new Person();
                p.AppUserId = user.Id;
                p.PersonType = user.PersonType;
                p.FirstName = Input.FirstName;
                p.LastName = Input.LastName;
                p.FamilyId = f.FamilyId;
                p.Logo = "Icons/" + logo;
                _context.Add(p);
                _context.SaveChanges();

<div class="form-group">
                <label asp-for="Input.FirstName"></label>
                <input asp-for="Input.FirstName" class="form-control" />
                <span asp-validation-for="Input.FirstName" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Input.LastName"></label>
                <input asp-for="Input.LastName" class="form-control" />
                <span asp-validation-for="Input.LastName" class="text-danger"></span>
            </div>
            
            <div class="form-group">
                <label asp-for="Input.PersonType" class="control-label"></label>
                <select asp-for="Input.PersonType" class="form-control" asp-items="@Html.GetEnumSelectList<PersonType>()"></select>
                <span asp-validation-for="Input.PersonType" class="text-danger"></span>
            </div>
~~~

~~~person index
@model IEnumerable<Domain.Person>

@{
    ViewData["Title"] = "Index";
}


<div class="row">
<div class="col-4">
    <table class="table">
    <thead>
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.FirstName)
        </th>
        
    </tr>
    </thead>
    <tbody>
    @foreach (var item in Model) {
        <tr>
            <td>
                <img src="Icons/001-lego.png" alt="logo" width="64" height="64"/>
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.FirstName)
            </td>

        </tr>
    }
    </tbody>
</table>
</div>
<div class="col">
    <div>
        <h3 id="monthAndYear">Month and Year</h3>
        <table class="table">
            <thead>
            <tr>
                <th class="tableText">Mon</th>
                <th>Tue</th>
                <th>Wed</th>
                <th>Thu</th>
                <th>Fri</th>
                <th>Sat</th>
                <th>Sun</th>
            </tr>
            </thead>
            <tbody id="calendar-body"></tbody>
        </table>
        <div>
            <button onclick="previous()">Previous</button>
            <button onclick="next()">Next</button>
        </div>
    </div>
</div>
</div>
~~~


<form action="/ControllerName/ActionName" asp-action="Register" method="post" role="form" class="ui large form">
....
</form>

var errors = ModelState.Values.SelectMany(v => v.Errors);