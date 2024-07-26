﻿using Microsoft.EntityFrameworkCore;
using server_to_do.Models;

namespace server_to_do.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Todo> Todos { get; set; }
        DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("todo_app"); //default schema
        }
    }
}
