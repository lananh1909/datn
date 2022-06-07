using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Business.EntityFrameworkCore
{
    public static class BusinessDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BusinessDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BusinessDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
