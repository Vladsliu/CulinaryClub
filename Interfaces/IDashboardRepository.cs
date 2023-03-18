using CookingClub.Models;

namespace CulinaryClub.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<MasterClass>> GetAllUserMasterClasses();
        Task<List<Club>> GetAllUserClubs();
    }
}
