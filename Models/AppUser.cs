using System.ComponentModel.DataAnnotations;

namespace CookingClub.Models
{
	public class AppUser
	{
		[Key]
		public string Id { get; set; }
		public int? Dishes { get; set; }
		public int? Rating { get; set; }
		public Address? Address { get; set; }
		public ICollection<Club> Clubs { get; set; }
		public ICollection<MasterClass> MasterClasses { get; set; }
	}
}
