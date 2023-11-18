namespace MinimalBookAPI.Repository
{
    public interface IRepository<T>
    {
        public List<T> GetList();
        public T Get(int id);
        public void Add(Book book);
        public void Update(int id,Book book);
        public void Delete(int id);
    }
}
