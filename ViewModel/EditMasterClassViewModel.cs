using CookingClub.Data.Enum;
using CookingClub.Models;

namespace CulinaryClub.ViewModel
{
    public class EditMasterClassViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public MasterClassCategory MasterClassCategory { get; set; }
    }
}
