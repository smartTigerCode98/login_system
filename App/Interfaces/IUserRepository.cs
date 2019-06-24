using System.Collections.Generic;
using App.Details;

namespace App.Interfaces
{
    public interface IUserRepository
    {
        User FindUser(string email);
    }
}