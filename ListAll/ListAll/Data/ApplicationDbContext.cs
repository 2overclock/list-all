using System;
using System.Collections.Generic;
using System.Text;
using ListAll.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ListAll.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<List> List { get; set; }

        public DbSet<ListItem> ListItem { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// enable auto history functionality.
			modelBuilder.EnableAutoHistory(int.MaxValue);

			modelBuilder.Entity<>
		}
	}
}
