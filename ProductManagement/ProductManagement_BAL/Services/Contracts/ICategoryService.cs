using ProductManagementAdapters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementBusinessLibrary.Services.Contracts
{
    public interface ICategoryService
    {
        public Task<Category> AddCategory(Category category);
        public void DeleteCategory(Guid Id);
        public void UpdateCategory(Guid Id, Category category);
        public IEnumerable<Category> GetAllCategories();


    }
}
