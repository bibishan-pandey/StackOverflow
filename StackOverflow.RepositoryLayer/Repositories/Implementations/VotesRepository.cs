using System;
using System.Data.Entity;
using System.Linq;
using StackOverflow.DomainModels.DbContext;
using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Interfaces;

namespace StackOverflow.RepositoryLayer.Repositories.Implementations
{
    public class VotesRepository : IVotesRepository
    {
        private readonly StackOverflowDbContext _dbContext;

        public VotesRepository(StackOverflowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Vote> GetList()
        {
            return _dbContext.Votes;
        }

        public Vote GetById(int id)
        {
            return _dbContext.Votes.Find(id);
        }

        public void Insert(Vote model)
        {
            _dbContext.Votes.Add(model);
        }

        public void Update(Vote model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public void Delete(int? id)
        {
            var vote = _dbContext.Votes.Find(id);
            _dbContext.Votes.Remove(vote ?? throw new InvalidOperationException());
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
