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

        public async Task<IActionResult> Edit(int id)
        {
            var masterClass = await _masterClassRepository.GetByIdAsync(id);
            if (masterClass == null) return View("Error");
            var masterClassVM = new EditMasterClassViewModel
            {
                Title = masterClass.Title,
                Description = masterClass.Description,
                AddressId = masterClass.AddressId,
                Address = masterClass.Address,
                URL = masterClass.Image,
                MasterClassCategory = masterClass.MasterClassCategory
            };
            return View(masterClassVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditMasterClassViewModel masterClassVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit master class");
                return View("Error", masterClassVM);
            }

            var userMasterClass = await _masterClassRepository.GetByIdAsyncNoTracking(id);

            if (userMasterClass != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userMasterClass.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(masterClassVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(masterClassVM.Image);

                var masterClass = new MasterClass
                {
                    Id = id,
                    Title = masterClassVM.Title,
                    Description = masterClassVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = masterClassVM.AddressId,
                    Address = masterClassVM.Address
                };

                _masterClassRepository.Update(masterClass);

                return RedirectToAction("Index");
            }
            else
            {
                return View(masterClassVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var masterClassDetails = await _masterClassRepository.GetByIdAsync(id);
            if (masterClassDetails == null) return View("Error");
            return View(masterClassDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var masterClassDetails = await _masterClassRepository.GetByIdAsync(id);
            if (masterClassDetails == null) return View("Error");

            _masterClassRepository.Delete(masterClassDetails);
            return RedirectToAction("Index");
        }
    }
}