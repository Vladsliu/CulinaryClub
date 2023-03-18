using CookingClub.Models;
using CulinaryClub.Data;
using CulinaryClub.Interfaces;

namespace CulinaryClub.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Club>> GetAllUserClubs()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userClubs = _context.Clubs.Where(r => r.AppUser.Id == curUser.ToString());
            return userClubs.ToList();
        }

        public async Task<List<MasterClass>> GetAllUserMasterClasses()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userMasterClasses = _context.MasterClasses.Where(r => r.AppUser.Id == curUser.ToString());
            return userMasterClasses.ToList();
        }
    }
}
