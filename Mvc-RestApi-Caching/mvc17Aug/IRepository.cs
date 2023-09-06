namespace mvc17Aug
{
    public interface IRepository<T> where T : class
    {
        T[] GetAll();
        T? GetById(int id);
        void Update(T entity);
        void Delete(int id);  
        void Add(T entity);
    }
}
