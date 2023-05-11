using Azure.Identity;
using CulinaryClub.Interfaces;
using CulinaryClub.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryClub.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) 
        {
        _userRepository = userRepository;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUser();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users) 
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Dishes = user.Dishes,
                    Rating = user.Rating,
                    ProfileImageUrl = user.ProfileImageUrl,
                };
                result.Add(userViewModel);
            }
            return View(result);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var userDetailViewmodel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Dishes = user.Dishes,
                Rating = user.Rating,
            };
            return View(userDetailViewmodel);
        }
    }
}
