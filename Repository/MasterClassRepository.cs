using CookingClub.Models;
using CulinaryClub.Data;
using CulinaryClub.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CulinaryClub.Repository
{
    public class MasterClassRepository : IMasterClassRepository
    {
        private readonly ApplicationDbContext _context;
        public MasterClassRepository(ApplicationDbContext context)
        {
            _context= context;
        }

        public bool Add(MasterClass masterClass)
        {
            _context.Add(masterClass);
            return Save();
        }

        public bool Delete(MasterClass masterClass)
        {
            _context.Remove(masterClass);
            return Save();
        }

        public async Task<IEnumerable<MasterClass>> GetAll()
        {
            return await _context.MasterClasses.ToListAsync();
        }

        public async Task<MasterClass> GetByIdAsync(int id)
        {
            return await _context.MasterClasses.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<MasterClass> GetByIdAsyncNoTracking(int id)
        {
            return await _context.MasterClasses.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<MasterClass>> GetClubByCity(string city)
        {
            return await _context.MasterClasses.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(MasterClass masterClass)
        {
            _context.Update(masterClass);
            return Save();
        }
    }
}
