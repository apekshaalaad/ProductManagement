using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementAdapters.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }

        [Required]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public int QuantityPerUnit { get; set; }

        [Required]
        public float UnitPrice { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        [Required]
        public int UnitsOnOrder { get; set; }

        public Guid CategoryId { get; set; }

        //public Category Category { get; set; }


    }
}
