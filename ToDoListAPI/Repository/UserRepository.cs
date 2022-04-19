using ToDoListAPI.Data;
using ToDoListAPI.Model;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Repository.Interfaces;

namespace ToDoListAPI.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
