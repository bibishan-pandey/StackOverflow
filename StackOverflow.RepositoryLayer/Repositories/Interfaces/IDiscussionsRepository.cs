using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Generics;

namespace StackOverflow.RepositoryLayer.Repositories.Interfaces
{
    public interface IDiscussionsRepository : IGenericRepository<Discussion>
    {
        int CountDiscussionVotes(int discussionId);
        int CountDiscussionComments(int discussionId);
        int CountDiscussionViews(int discussionId, int value);
    }
}
