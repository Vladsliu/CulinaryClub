﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingClub.Models
{
	public class AppUser : IdentityUser
	{
		public int? Dishes { get; set; }
		public int? Rating { get; set; }
		public string? ProfileImageUrl { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		[ForeignKey("Address")]
		public int? AddressId { get; set; } 
		public Address? Address { get; set; }
        public ICollection<Club> Clubs { get; set; }
		public ICollection<MasterClass> MasterClasses { get; set; }
	}
}
