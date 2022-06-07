using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Auth.EntityFrameworkCore
{
    public static class AuthDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AuthDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 11)));
        }

        public static void Configure(DbContextOptionsBuilder<AuthDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
