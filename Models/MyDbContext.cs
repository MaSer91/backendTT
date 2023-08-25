//using APIAdminUsers.Models;
using APIAdminUsers.Context;
using Microsoft.EntityFrameworkCore;

namespace APIAdminUsers.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Departamento> Depto { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
