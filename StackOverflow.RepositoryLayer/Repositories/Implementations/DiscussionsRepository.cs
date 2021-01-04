using System;
using System.Data.Entity;
using System.Linq;
using StackOverflow.DomainModels.DbContext;
using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Interfaces;

namespace StackOverflow.RepositoryLayer.Repositories.Implementations
{
    public class DiscussionsRepository : IDiscussionsRepository
    {
        private readonly StackOverflowDbContext _dbContext;

        public DiscussionsRepository(StackOverflowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Discussion> GetList()
        {
            return _dbContext.Discussions.OrderByDescending(d => d.CreatedAt);
        }

        public Discussion GetById(int id)
        {
            return _dbContext.Discussions.Find(id);
        }

        public void Insert(Discussion model)
        {
            _dbContext.Discussions.Add(model);
        }

        public void Update(Discussion model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public void Delete(int? id)
        {
            var discussion = _dbContext.Discussions.Find(id);
            _dbContext.Discussions.Remove(discussion ?? throw new InvalidOperationException());
        }

        public int CountDiscussionVotes(int discussionId)
        {
            return _dbContext.Votes
                .Where(v => v.DiscussionId == discussionId)
                .ToList()
                .Count;

        }

        public int CountDiscussionComments(int discussionId)
        {
            return _dbContext.Comments
                .Where(c => c.DiscussionId == discussionId)
                .ToList()
                .Count;
        }

        public int CountDiscussionViews(int discussionId, int value)
        {
            var discussion = _dbContext.Discussions.Find(discussionId);
            if (discussion != null)
            {
                discussion.Views += value;
                Save();
            }
            else throw new NullReferenceException();
            return discussion.Views;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
