using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunnWebApplication1.Data;
using RunnWebApplication1.Interfaces;
using RunnWebApplication1.Models;

namespace RunnWebApplication1.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;

        public ClubController( IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();
            return View(clubs);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }
    }
}
