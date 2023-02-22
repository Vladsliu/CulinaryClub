namespace CookingClub.Models
{
	public class AppUser
	{
		public int? Dishes { get; set; }
		public int? Rating { get; set; }
		public Address? Address { get; set; }
		public ICollection<Club> Clubs { get; set; }
		public ICollection<MasterClass> MasterClasses { get; set; }
	}
}
