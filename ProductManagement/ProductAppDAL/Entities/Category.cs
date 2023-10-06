using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementAdapters.Entities
{
    public class Category
    {
        /*public Category()
        {
            Products = new List<Product>();
        }*/
        public Guid CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}
