using System;
using System.Data.Entity;
using System.Linq;
using StackOverflow.DomainModels.DbContext;
using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Interfaces;

namespace StackOverflow.RepositoryLayer.Repositories.Implementations
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly StackOverflowDbContext _dbContext;

        public CommentsRepository(StackOverflowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Comment> GetList()
        {
            return _dbContext.Comments.OrderByDescending(c => c.CreatedAt);
        }

        public Comment GetById(int id)
        {
            return _dbContext.Comments.Find(id);
        }

        public void Insert(Comment model)
        {
            _dbContext.Comments.Add(model);
        }

        public void Update(Comment model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public int CountCommentVotes(int commentId)
        {
            return _dbContext.Votes
                .Where(v => v.CommentId == commentId)
                .ToList()
                .Count;
        }

        public void Delete(int? id)
        {
            var comment = _dbContext.Comments.Find(id);
            _dbContext.Comments.Remove(comment ?? throw new InvalidOperationException());
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
