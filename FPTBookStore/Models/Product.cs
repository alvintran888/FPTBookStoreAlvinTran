
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTBookStore.Models
{
    public class Product
    {
      
        // properties Id, Name, Price,Quantity,  Description
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Book name must between 5 to 30 charecter"), MinLength(5)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 101, ErrorMessage = "Book unit price must be 1 to 100 dolar")]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "Quantity must be 1 to 1000")]
        public int Quantity { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        
        public string Image { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }






    }
}
