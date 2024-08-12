using System.ComponentModel.DataAnnotations;

namespace Shopping_MVC.Models
{
    public class User
    {

        public int Id { get; set; }
        [Required]
        
        public string Name { get; set; }
        [Required]

        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be exactly 11 digits")]
       // [Range(11,11 ,ErrorMessage ="noooooooooooo")] 
        public string Number { get; set; }
        [Required]
       
        public string Passward { get; set; }
    }
}
