namespace CulinaryClub.ViewModel
{
    public class UserDetailViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int? Dishes { get; set; }
        public int? Rating { get; set; }

        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
