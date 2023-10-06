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
    public class CategoryService:ICategoryService
    {
        public readonly IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository)
        {
            this._repository = repository;
        }
        //Create Method
        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                Guid categoryId = Guid.NewGuid();
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category));
                }
                else
                {
                    category.CategoryId = categoryId;
                    return await _repository.Create(category);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteCategory(Guid Id)
        {
            try
            {
                if (Id != null)
                {
                    var obj = _repository.GetAll().Where(x => x.CategoryId == Id).FirstOrDefault();
                    _repository.Delete(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateCategory(Guid Id, Category category)
        {
            try
            {
                if (Id != null && category!=null)
                {
                    var obj = _repository.GetAll().Where(x => x.CategoryId == Id).FirstOrDefault();
                    obj.CategoryName = category.CategoryName;
                    obj.Description = category.Description;

                    if (obj != null) _repository.Update(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Category> GetAllCategories()
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
