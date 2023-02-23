using CookingClub.Models;
using CulinaryClub.Data;
using CulinaryClub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CulinaryClub.Controllers
{
	public class ClubController : Controller
	{
		private readonly IClubRepository _clubRepository;

		public ClubController(IClubRepository clubRepository)
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
