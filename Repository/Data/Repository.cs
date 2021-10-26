using Repository.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext context;
        private Microsoft.EntityFrameworkCore.DbSet<T> entities;

        public Repository(DataContext _context)
        {
            context = _context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return entities.AsEnumerable();
        }

        public T Get(int id)
        {
            return entities.Find(keyValues: id);
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
