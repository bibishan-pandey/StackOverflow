using System;
using System.Data.Entity;
using System.Linq;
using StackOverflow.DomainModels.DbContext;
using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Interfaces;

namespace StackOverflow.RepositoryLayer.Repositories.Implementations
{
    public class VoteTypesRepository : IVoteTypesRepository
    {
        private readonly StackOverflowDbContext _dbContext;

        public VoteTypesRepository(StackOverflowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<VoteType> GetList()
        {
            return _dbContext.VoteTypes;
        }

        public VoteType GetById(int id)
        {
            return _dbContext.VoteTypes.Find(id);
        }

        public void Insert(VoteType model)
        {
            _dbContext.VoteTypes.Add(model);
        }

        public void Update(VoteType model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public void Delete(int? id)
        {
            var voteType = _dbContext.VoteTypes.Find(id);
            _dbContext.VoteTypes.Remove(voteType ?? throw new InvalidOperationException());
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
