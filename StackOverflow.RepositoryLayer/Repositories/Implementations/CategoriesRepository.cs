using System;
using System.Data.Entity;
using System.Linq;
using StackOverflow.DomainModels.DbContext;
using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Interfaces;

namespace StackOverflow.RepositoryLayer.Repositories.Implementations
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly StackOverflowDbContext _dbContext;

        public CategoriesRepository(StackOverflowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Category> GetList()
        {
            return _dbContext.Categories;
        }

        public Category GetById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public void Insert(Category model)
        {
            _dbContext.Categories.Add(model);
            Save();
        }

        public void Update(Category model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            Save();
        }

        public void Delete(int? id)
        {
            var category = _dbContext.Categories.Find(id);
            _dbContext.Categories.Remove(category ?? throw new InvalidOperationException());
            Save();
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
