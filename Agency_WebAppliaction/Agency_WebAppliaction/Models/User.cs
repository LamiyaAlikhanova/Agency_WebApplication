using Microsoft.AspNetCore.Identity;

namespace Agency_WebAppliaction.Models
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
