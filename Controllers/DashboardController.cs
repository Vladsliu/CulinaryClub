using CulinaryClub.Data;
using CulinaryClub.Interfaces;
using CulinaryClub.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryClub.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardController(IDashboardRepository dashboardRepository)
        {
             _dashboardRepository = dashboardRepository;
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
    }
}
