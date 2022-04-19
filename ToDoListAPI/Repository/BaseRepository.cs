using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;
using ToDoListAPI.Repository.Interfaces;

namespace ToDoListAPI.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _db;

        public BaseRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>()
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _db.Set<T>()
                            .FindAsync(Id);
        }

        public async Task<T> AddAsync(T obj)
        {
            await _db.Set<T>().AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task UpdateAsync(T obj)
        {
            _db.Set<T>().Update(obj);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T obj)
        {
            _db.Set<T>().Remove(obj);
            await _db.SaveChangesAsync();
        }
    }
}
