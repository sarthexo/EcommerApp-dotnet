using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Entities
{
   public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty!;
        public String? Description { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
