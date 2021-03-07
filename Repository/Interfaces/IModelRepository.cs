using DataRepository.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models.Interfaces
{
    public interface IModelRepository<T> where T : BaseModel
    {
        TodosDbContext DB { get; }
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(string id);

        bool EntityExists(string id);
    }
}
