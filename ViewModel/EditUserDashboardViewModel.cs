﻿namespace CulinaryClub.ViewModel
{
    public class EditUserDashboardViewModel
    {
        public string Id { get; set; }
        public int? Dishes { get; set; }
        public int? Rating { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public IFormFile Image { get; set; }
    }
}
