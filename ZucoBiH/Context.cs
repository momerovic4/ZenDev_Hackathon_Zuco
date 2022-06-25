using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using ZucoBiH.Models;

namespace ZucoBiH
{
    public class Context : DbContext
    {

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Liked> Likes { get; set; }

        public Context([NotNull] DbContextOptions<Context> options) : base(options)
        {
            var conn = (Microsoft.Data.SqlClient.SqlConnection)Database.GetDbConnection();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var dbConnString = @"Server=tcp:znedevtest.database.windows.net,1433;Initial Catalog=ZenDev;Persist Security Info=False;User ID=zendevadmin;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(dbConnString);
          
        }

    }
}
