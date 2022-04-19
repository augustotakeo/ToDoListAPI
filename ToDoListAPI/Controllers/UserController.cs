using ToDoListAPI.Model;
using ToDoListAPI.Repository.Interfaces;
using ToDoListAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListAPI.Controllers
{
    public class UserController : BaseController<User>
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }

}
