using System.Data.Entity;
using StackOverflow.DomainModels.Models;

namespace StackOverflow.DomainModels.DbContext
{
    public class StackOverflowDbContext : System.Data.Entity.DbContext
    {
        public StackOverflowDbContext() : base("StackOverflowDbContext") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteType> VoteTypes { get; set; }
    }
}
