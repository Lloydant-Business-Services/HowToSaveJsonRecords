using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace TestForSavingJson.Model
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public List<Root>? UserDetails { get; set;}
    }

}
