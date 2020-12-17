using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Day9_HW.Models;
using Microsoft.EntityFrameworkCore;

namespace Day9_HW.Controllers
{
    public class HomeController : Controller
    {
        private StudentContext db;

        public HomeController(StudentContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Students.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
