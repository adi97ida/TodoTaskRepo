using DataRepository.Models;
using DataRepository.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataRepository.Models.DB;

namespace DataRepository.DB
{
    public class ModelRepository<T> : IModelRepository<T> where T : BaseModel
    {
        protected readonly TodosDbContext context;
        public TodosDbContext DB { get; }
        private readonly DbSet<T> entities;

        public ModelRepository(TodosDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
            DB = context;
        }
        public async Task<List<T>> GetAll()
        {
            return await entities.ToListAsync(); ;
        }
        public async Task<T> GetById(string id)
        {
            return await entities.FindAsync(id);
        }
        public async Task<T> Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            var newEntity = entities.Add(entity);
            await context.SaveChangesAsync();


            return await context.FindAsync<T>(newEntity.Entity.Id);
        }
        public async Task<T> Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();

            if (!EntityExists(entity.Id))
            {
                return null;
            }

            return await context.FindAsync<T>(entity.Id); ;
        }
        public async Task<T> Delete(string id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            try
            {
                await context.SaveChangesAsync();
            } catch (DbUpdateException)
            {
                return null;
            }
            return entity;
        }

        public bool EntityExists(string id)
        {
            return entities.Any(e => e.Id == id);
        }
    }
}
