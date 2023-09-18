using Labs.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labs.Domain.Entities
{
    public class User
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}