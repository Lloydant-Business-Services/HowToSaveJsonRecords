using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TestForSavingJson.Model;

namespace TestForSavingJson.Data
{
    public class UserDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Users>()
            .Property(e => e.UserDetails)
            .HasConversion(
                v => JsonConvert.SerializeObject(v,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }),
                v => JsonConvert.DeserializeObject<List<Root>?>(v,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() })
            );
        }
         public DbSet<Users> Users { get; set; }  
    }
}
