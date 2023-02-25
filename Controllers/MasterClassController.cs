using CookingClub.Models;
using CookingClub.Services;
using CulinaryClub.Data;
using CulinaryClub.Interfaces;
using CulinaryClub.Repository;
using CulinaryClub.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CulinaryClub.Controllers
{
	public class MasterClassController : Controller
	{
		private readonly IMasterClassRepository _masterClassRepository;
        private readonly IPhotoService _photoService;
		public MasterClassController(IMasterClassRepository masterClassRepository, IPhotoService photoService)
		{
			_masterClassRepository = masterClassRepository;
            _photoService = photoService;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMasterClassViewModel masterClassVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(masterClassVM.Image);

                var masterClass = new MasterClass
                {
                    Title = masterClassVM.Title,
                    Description = masterClassVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = masterClassVM.Address.Street,
                        City = masterClassVM.Address.City,
                        State = masterClassVM.Address.State
                    }
                };
                _masterClassRepository.Add(masterClass);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload error");
            }
            return View(masterClassVM);
        }
    }
}