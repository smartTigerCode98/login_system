using System.Collections.Generic;
using System.Linq;
using App.Details;
using App.Interfaces;

namespace App.Repositories
{
    public class InMemoryUserRepo : IUserRepository
    {
        private readonly List<User> _users;

        public InMemoryUserRepo()
        {
            _users = new List<User>
            {
                new User("danko98uran@gmail.com", "MyPassword123"),
                new User("innayelle_arts@gmail.com", "SenyaMyCat123")
            };
        }
        public User FindUser(string email)
        {
            return _users.FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}