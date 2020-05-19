using FootBallLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallLib
{
    public class FootBallContext : DbContext
    {
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Transfer> Tranfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress1;Initial Catalog=FootBall;Integrated Security=True");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>().Property(t => t.Stamnummer).ValueGeneratedNever();
        }
    }
}
