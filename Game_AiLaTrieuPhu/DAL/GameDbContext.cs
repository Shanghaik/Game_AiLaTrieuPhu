using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_AiLaTrieuPhu.DAL
{
    internal class GameDbContext : DbContext // Tạo ra để thực hiện kết nối và
                                             // thao tác trên db thông qua EFCore
    {
        public GameDbContext() { }
        public GameDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Shanghaik;Initial Catalog=DHBC_Data;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
