using CulinaryClub.Data;
using CulinaryClub.Interfaces;
using CulinaryClub.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryClub.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;
        public DashboardController(IDashboardRepository dashboardRepository,
            IHttpContextAccessor httpContextAccessor, IPhotoService photoService)
        {
            _dashboardRepository = dashboardRepository;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            var userMasterClasses = await _dashboardRepository.GetAllUserMasterClasses();
            var userClubs = await _dashboardRepository.GetAllUserClubs();
            var dashboardViewModel = new DashboardViewModel()
            {
                MasterClasses = userMasterClasses,
                Clubs = userClubs
            };
            return View(dashboardViewModel);
        }

        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _dashboardRepository.GetUserById(curUserId);

            if (user == null) return View("Error");

            var editUserViewModel = new EditUserDashboardViewModel()
            {
                Id = curUserId,
                Dishes = user.Dishes,
                Rating = user.Rating,
                ProfileImageUrl = user.ProfileImageUrl,
                City = user.City,
                State = user.State
            };

            return View(editUserViewModel);
        }
    }
}
