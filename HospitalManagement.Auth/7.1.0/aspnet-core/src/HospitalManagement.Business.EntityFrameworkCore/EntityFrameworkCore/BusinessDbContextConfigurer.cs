using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Business.EntityFrameworkCore
{
    public static class BusinessDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BusinessDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 11)));
        }

        public static void Configure(DbContextOptionsBuilder<BusinessDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
