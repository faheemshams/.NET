namespace mvc17Aug
{
    public interface IRepository<T>
    {
        T[] GetAll();
        T? GetById(int id);
        void Update(T entity);
        void Delete(int id);  
        void Add(T entity);
    }
}
