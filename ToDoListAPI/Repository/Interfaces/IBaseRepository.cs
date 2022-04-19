namespace ToDoListAPI.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync();

        public Task<T> GetByIdAsync(int Id);

        public Task<T> AddAsync(T obj);

        public Task UpdateAsync(T obj);

        public Task DeleteAsync(T obj);
    }
}
