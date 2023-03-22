using CookingClub.Data.Enum;
using CookingClub.Models;

namespace CulinaryClub.ViewModel
{
    public class CreateMasterClassViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public MasterClassCategory MasterClassCategory { get; set; }
        public string AppUserId { get; set; }//?
    }
}
