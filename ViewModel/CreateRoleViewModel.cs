using System.ComponentModel.DataAnnotations;

namespace Mult2.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
