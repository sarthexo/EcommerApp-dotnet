using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Products
{
  public  class UpdateProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Range(0.01,999999)]
        public decimal Price { get; set; }

        [Range(0,int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

    }
}
