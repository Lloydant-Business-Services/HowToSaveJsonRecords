using TestForSavingJson.Model;

namespace TestForSavingJson.Data
{
    public class Mutation
    {
        public async Task<Users> SaveUsersAsync([Service]UserDbContext context,Users user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
