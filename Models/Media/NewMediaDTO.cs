using System.ComponentModel.DataAnnotations;

namespace API_Test.Models.Media
{
    public class NewMediaDTO
    {
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(255, ErrorMessage = "Max Length is 255")]
        public string Description {get;set;}
    }
}