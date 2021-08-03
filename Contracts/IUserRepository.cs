using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAllUsers(bool trackChanges);
        Users GetUser(int id, bool trackChanges);

        IEnumerable<Users> GetUsersById(IEnumerable<int> ids, bool trackChanges);
        void CreateUser(Users user);
        void DeleteUser(Users user);

    }
}
