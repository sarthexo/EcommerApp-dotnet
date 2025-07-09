using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Entities
{
   public class Cart
    {
        [Key]
        public Guid UserId { get; set; }
        public List<CartItem> Items { get; set; } = new();
    }
}
