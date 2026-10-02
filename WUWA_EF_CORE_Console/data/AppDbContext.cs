using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUWA_CHARACTER_OOP.Models;
using WUWA_WINFORMS_POSTGRE.Models;

namespace WUWA_WINFORMS_POSTGRE
{
    public class AppDbContext : DbContext
    {
        private const string ConnectionString = "Host = localhost; Port = 5433; Username = postgres; Password = 123; Database = Wuwa_EF_Core_2";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public DbSet<Character> Character { get; set; }
        public DbSet<Weapon> Weapon { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Rarity> Rarity { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Talant> Talants { get; set; }
    }
}
