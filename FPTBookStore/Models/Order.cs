using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FPTBookStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        
        public double TotalPrice { get; set; }
        public ICollection<CartItem> cartItems { get; set; }

    }
}
