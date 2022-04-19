using ToDoListAPI.Model;
using ToDoListAPI.Data;
using ToDoListAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListAPI.Controllers
{
    public class AnnotationController : BaseController<Annotation>
    {
        private readonly IAnnotationRepository _repo;

        public AnnotationController(IAnnotationRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
