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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger _logger;
        public CategoryRepository(ILogger<Category> logger, ApplicationDbContext _context)
        {
            _logger = logger;
            context = _context;
        }
        public async Task<Category> Create(Category category)
        {
            try
            {
                if (category != null)
                {
                    var obj = context.Add(category);
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
        public void Delete(Category category)
        {
            try
            {
                if (category != null)
                {
                    var obj = context.Remove(category);
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
        public IEnumerable<Category> GetAll()
        {
            try
            {
                var obj = context.Categories.ToList();
                if (obj != null) return obj;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Category GetById(Guid Id)
        {
            try
            {
                if (Id != null)
                {
                    var Obj = context.Categories.FirstOrDefault(x => x.CategoryId == Id);
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
        public void Update(Category category)
        {
            try
            {
                if (category != null)
                {
                    var obj = context.Update(category);
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
