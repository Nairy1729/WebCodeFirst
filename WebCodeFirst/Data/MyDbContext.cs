using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebCodeFirst.Models;

namespace WebCodeFirst.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
