using CookingClub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CulinaryClub.Data
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
		{

		}
		public DbSet<MasterClass> MasterClasses { get; set; }
		public DbSet<Club> Clubs { get; set; }
		public DbSet<Address> Addresses { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
