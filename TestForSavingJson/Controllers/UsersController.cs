using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestForSavingJson.Data;
using TestForSavingJson.Model;

namespace TestForSavingJson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;
        public UsersController(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        [HttpPost]
        public IEnumerable<Users> CreateUsers(Users model)
        {
            _userDbContext.Users.Add(model);
            _userDbContext.SaveChanges();
                var query = from b in _userDbContext.Users
                            orderby b.Id
                            select b;
            return query.ToList();
        }
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
                var query = from b in _userDbContext.Users
                            orderby b.Id
                            select b;
            return  query.ToList();
        }
    }
}
