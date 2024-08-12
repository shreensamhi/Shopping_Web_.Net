using System.ComponentModel.DataAnnotations;

namespace Shopping_MVC.Models
{
   
        public class Product
        {
            public int Id { get; set; }
            [Required]
            [StringLength(100,ErrorMessage ="not more 100 char")]
            public string Name { get; set; }
            [Required]
            public int Price { get; set; }
          

        }
    
}
