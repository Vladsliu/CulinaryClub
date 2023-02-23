using CookingClub.Models;
using CulinaryClub.Data;
using CulinaryClub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CulinaryClub.Controllers
{
	public class MasterClassController : Controller
	{
		private readonly IMasterClassRepository _masterClassRepository;
		public MasterClassController(IMasterClassRepository masterClassRepository)
		{
			_masterClassRepository = masterClassRepository;
		}
		public async Task<IActionResult> Index()
		{
			IEnumerable<MasterClass> masterClasses = await _masterClassRepository.GetAll();
			return View(masterClasses);
		}
        public async Task<IActionResult> Detail(int id)
        {
            MasterClass masterClass = await _masterClassRepository.GetByIdAsync(id);
            return View(masterClass);
        }
    }
}