using EmpowerIDEMSApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpowerIDEMSApp.DataAccessLayer
{
    public class EMSDbContext:DbContext
    {
        public EMSDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee>  Employees { get; set; }
    }
}
