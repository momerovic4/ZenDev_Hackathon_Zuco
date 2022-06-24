using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ZucoBiH
{
    public class Context : DbContext
    {
       

        public Context([NotNull] DbContextOptions<Context> options) : base(options)
        {
            var conn = (Microsoft.Data.SqlClient.SqlConnection)Database.GetDbConnection();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var dbConnString = @"";

            optionsBuilder.UseSqlServer(dbConnString);
          
        }

    }
}
