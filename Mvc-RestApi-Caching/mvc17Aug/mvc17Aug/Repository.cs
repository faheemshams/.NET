using Microsoft.EntityFrameworkCore;
using mvc17Aug.Models;

namespace mvc17Aug
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext context;

        public Repository(DatabaseContext context)
        {
            this.context = context;
        }
    
        public void Add(T entity)
        {
            context.Set<T>().Add(entity); 
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            T Key = GetById(id);
            context.Set<T>().Remove(Key);
            context.SaveChanges();
        }

        public T[] GetAll()
        {
            return context.Set<T>().ToArray();  
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
           context.Entry(entity).State = EntityState.Modified;
           context.SaveChanges();
        }
    }
}
