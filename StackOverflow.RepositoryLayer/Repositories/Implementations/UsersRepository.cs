using System;
using System.Data.Entity;
using System.Linq;
using StackOverflow.DomainModels.DbContext;
using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Interfaces;

namespace StackOverflow.RepositoryLayer.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly StackOverflowDbContext _dbContext;

        public UsersRepository(StackOverflowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<User> GetList()
        {
            return _dbContext.Users
                .Where(user => !user.IsAdmin)
                .OrderByDescending(user => user.CreatedAt);
        }

        public User GetById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public void Insert(User model)
        {
            _dbContext.Users.Add(model);
        }

        public void Update(User model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public void UpdatePassword(User model)
        {
            
        }

        public User GetByEmail(string email)
        {
            return _dbContext.Users
                .SingleOrDefault(user => !user.IsAdmin && user.Email == email);
        }

        public User GetByEmailPassword(string email, string password)
        {
            return _dbContext.Users
                .SingleOrDefault(user => !user.IsAdmin 
                                        && user.Email == email
                                        && user.Password == password);
        }

        public int GetRecentUser()
        {
            return _dbContext.Users
                .Select(user => user.Id)
                .Max();
        }

        public void Delete(int? id)
        {
            var user = _dbContext.Users.Find(id);
            _dbContext.Users.Remove(user ?? throw new InvalidOperationException());
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
