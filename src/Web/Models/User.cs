using System.Collections.Generic;

namespace Web.Models
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<Role> Roles { get; set; }

    }

    public enum Role
    {
        User,
        Administrator
    }
}