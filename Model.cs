using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lab_07
{
    public class BloggingContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TaskToDo> Tasks { get; set; }


        public string ConnectionString { get; }

        public BloggingContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }
    }

    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public long RoleId { get; set; }
        public List<TaskToDo> Tasks { get; } = new();
    }

    public class Role
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }

    public class TaskToDo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public long AssignedUserId { get; set; }
    }
}
