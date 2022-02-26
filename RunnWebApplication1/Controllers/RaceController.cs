using Microsoft.AspNetCore.Mvc;
using RunnWebApplication1.Data;
using RunnWebApplication1.Models;

namespace RunnWebApplication1.Controllers
{
  

    public class RaceController : Controller
    {

        private readonly ApplicationDbContext _context;

        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Race> races = _context.Races.ToList();
            return View(races);
        }
    }
}
