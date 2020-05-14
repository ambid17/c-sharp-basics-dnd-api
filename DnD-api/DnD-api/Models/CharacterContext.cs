using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_api.Models
{
    public class CharacterContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
            .HasOne(s => s.CharacterStats).WithOne(a => a.Character);
        }

        public CharacterContext(DbContextOptions<CharacterContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterStats> CharacterStats { get; set; }
    }
}
