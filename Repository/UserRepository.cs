using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public IEnumerable<Users> GetAllUsers(bool trackChanges) => 
            FindAll(trackChanges)
            .OrderBy(c => c.UserId)
            .ToList();

        public Users GetUser(int id, bool trackChanges) =>
            FindByCondition(c => c.UserId.Equals(id), trackChanges)
            .SingleOrDefault();

        public void CreateUser(Users user) => Create(user);

        public IEnumerable<Users> GetUsersById(IEnumerable<int> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.UserId), trackChanges)
            .ToList();

        public void DeleteUser(Users user)
        {
            Delete(user);
        }
    }
}
