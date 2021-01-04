using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Generics;

namespace StackOverflow.RepositoryLayer.Repositories.Interfaces
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        void UpdatePassword(User model);
        User GetByEmail(string email);
        User GetByEmailPassword(string email, string password);
        int GetRecentUser();
    }
}
