using Hospital.DAL.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Hospital.UI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _dbContext;

        public DepartmentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      
        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> LoadMore(int skip = 0, int take = 4)
        {
            var departments = await _dbContext.Departments
                .Include(d => d.Doctors)
                .OrderBy(d => d.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            ViewBag.Skip = skip; 
            return PartialView("_DepartmentListPartial", departments);
        }
    }
}
