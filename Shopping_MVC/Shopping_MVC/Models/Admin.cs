using System.ComponentModel.DataAnnotations;

namespace Shopping_MVC.Models
{
   
        public class Admin
        {
            public int Id { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "length must be more 5")]

            public string Name { get; set; }
            [Required]
        [StringLength(11,ErrorMessage ="must be 11 numbers")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be exactly 11 digits")]

        public string Number { get; set; }
            public string Passward { get; set; }
        }
    
}
