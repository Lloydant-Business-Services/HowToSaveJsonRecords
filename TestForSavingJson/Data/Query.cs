using Microsoft.EntityFrameworkCore;
using TestForSavingJson.Model;

namespace TestForSavingJson.Data
{
    public class Query
    {
        public async Task<List<Users>> GetAllUsers([Service] UserDbContext userDbContext)
        {
            return  await userDbContext.Users.ToListAsync();
        }
    }
}
