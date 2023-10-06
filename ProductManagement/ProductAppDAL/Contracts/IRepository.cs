using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementAdapters.Contracts
{
    public interface IRepository<T>
    {
        public Task<T> Create(T _object);
        public T GetById(Guid id);
        public void Delete(T _object);
        public void Update(T _object);
        public IEnumerable<T> GetAll();
    }

}
