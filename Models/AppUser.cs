using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingClub.Models
{
	public class AppUser : IdentityUser
	{
		//[Key]
		//public string Id { get; set; }6.03 tedi
		public int? Dishes { get; set; }
		public int? Rating { get; set; }
		[ForeignKey("Address")]
		public int AddressId { get; set; } 
		public Address? Address { get; set; }
		public ICollection<Club> Clubs { get; set; }
		public ICollection<MasterClass> MasterClasses { get; set; }
	}
}
