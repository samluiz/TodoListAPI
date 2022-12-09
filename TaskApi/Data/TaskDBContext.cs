﻿using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using TaskApi.Data.Map;
using TaskApi.Models;

namespace TaskApi.Data
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options)
            : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
