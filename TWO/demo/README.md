dotnet ef migrations add InitialDbCreation --project DAL.App.EF --startup-project WebApp
dotnet ef database update --project DAL.App.EF --startup-project WebApp

dotnet aspnet-codegenerator controller -name PersonsController          -actions -m Person          -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name FamiliesController       -actions -m Family        -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name PersonTypesController   -actions -m PersonType   -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

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