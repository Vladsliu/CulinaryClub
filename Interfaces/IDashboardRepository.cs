using CookingClub.Models;

namespace CulinaryClub.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<MasterClass>> GetAllUserMasterClasses();
        Task<List<Club>> GetAllUserClubs();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
