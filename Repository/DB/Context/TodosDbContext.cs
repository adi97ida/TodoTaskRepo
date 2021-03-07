using DataRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataRepository.Models.DB
{
    public class TodosDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<SubscribedUsers> SubscribedUsers { get; set; }
        public TodosDbContext(DbContextOptions<TodosDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscribedUsers>()
                .HasKey(su => new { su.UserId, su.TodoListId });

            modelBuilder.Entity<SubscribedUsers>()
                .HasOne(su => su.User)
                .WithMany(u => u.SubscribedLists)
                .HasForeignKey(su => su.UserId);

            modelBuilder.Entity<SubscribedUsers>()
                .HasOne(su => su.TodoList)
                .WithMany(t => t.SubscribedUsers)
                .HasForeignKey(su => su.TodoListId);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "test1",
                    Password = "test1",
                    PhoneNo = "12345678"
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "test2",
                    Password = "test2",
                    PhoneNo = "12345678"
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "test3",
                    Password = "test3",
                    PhoneNo = "12345678"
                }
            ); ;
        }
    }
}
