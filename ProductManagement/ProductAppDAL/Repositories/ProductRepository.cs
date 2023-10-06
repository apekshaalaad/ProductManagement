using Microsoft.Extensions.Logging;
using ProductManagementAdapters.Contracts;
using ProductManagementAdapters.Data;
using ProductManagementAdapters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementAdapters.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger _logger;
        public ProductRepository(ILogger<Product> logger, ApplicationDbContext _context)
        {
            _logger = logger;
            context = _context;

        }
        public async Task<Product> Create(Product product)
        {
            try
            {
                if (product != null)
                {
                    var obj = context.Products.Add(product);
                    await context.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(Product product)
        {
            try
            {
                if (product != null)
                {
                    var obj = context.Remove(product);
                    if (obj != null)
                    {
                        context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Product> GetAll()
        {
            try
            {
                var obj = context.Products.ToList();
                if (obj != null) return obj;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Product GetById(Guid Id)
        {
            try
            {
                if (Id != null)
                {
                    var Obj = context.Products.FirstOrDefault(x => x.ProductId == Id);
                    if (Obj != null) return Obj;
                    else return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(Product product)
        {
            try
            {
                if (product != null)
                {
                    var obj = context.Products.Update(product);
                    if (obj != null) context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
