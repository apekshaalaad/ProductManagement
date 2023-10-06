using ProductManagementAdapters.Contracts;
using ProductManagementAdapters.Entities;
using ProductManagementBusinessLibrary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementBusinessLibrary.Services
{
    public class ProductService:IProductService
    {
        public readonly IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            this._repository = repository;
        }
        //Create Method
        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                Guid productId = Guid.NewGuid();
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product));
                }
                else
                {
                    product.ProductId= productId;   
                    return await _repository.Create(product);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteProduct(Guid Id)
        {
            try
            {
                if (Id != null)
                {
                    var obj = _repository.GetAll().Where(x => x.ProductId == Id).FirstOrDefault();
                    _repository.Delete(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateProduct(Guid Id,Product product)
        {
            try
            {
                if (Id != null && product!=null)
                {
                    var obj = _repository.GetAll().Where(x => x.ProductId == Id).FirstOrDefault();
                    obj.Name=product.Name;
                    obj.UnitPrice=product.UnitPrice;
                    obj.QuantityPerUnit=product.QuantityPerUnit;
                    obj.UnitsInStock=product.UnitsInStock;
                    obj.UnitsOnOrder=product.UnitsOnOrder; 
                    if (obj != null) _repository.Update(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
