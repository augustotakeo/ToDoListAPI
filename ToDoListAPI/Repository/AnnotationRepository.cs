using ToDoListAPI.Model;
using ToDoListAPI.Data;
using ToDoListAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Repository
{
    public class AnnotationRepository : BaseRepository<Annotation>, IAnnotationRepository
    {
        private readonly AppDbContext _db;

        public AnnotationRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
