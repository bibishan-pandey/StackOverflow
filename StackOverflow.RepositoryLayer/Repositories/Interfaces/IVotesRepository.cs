using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Generics;

namespace StackOverflow.RepositoryLayer.Repositories.Interfaces
{
    public interface IVotesRepository : IGenericRepository<Vote>
    {
    }
}
