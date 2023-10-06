using ProductManagementAdapters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementBusinessLibrary.Services.Contracts
{
    public interface IProductService
    {
        public Task<Product> AddProduct(Product product);
        public void DeleteProduct(Guid Id);

        public void UpdateProduct(Guid Id, Product product);

        public IEnumerable<Product> GetAllProducts();
    }
}
