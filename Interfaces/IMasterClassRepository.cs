using CookingClub.Models;

namespace CulinaryClub.Interfaces
{
    public interface IMasterClassRepository
    {
        Task<IEnumerable<MasterClass>> GetAll();
        Task<MasterClass> GetByIdAsync(int id);
        Task<IEnumerable<MasterClass>> GetClubByCity(string city);
        bool Add(MasterClass masterClass);
        bool Update(MasterClass masterClass);
        bool Delete(MasterClass masterClass);
        bool Save();
    }
}
