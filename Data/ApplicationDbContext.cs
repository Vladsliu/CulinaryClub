using CookingClub.Models;
using Microsoft.EntityFrameworkCore;

namespace CulinaryClub.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
		{

		}
		public DbSet<MasterClass> MasterClasses { get; set; }
		public DbSet<Club> Clubs { get; set; }
		public DbSet<Address> Addresses { get; set; }
	}
}
