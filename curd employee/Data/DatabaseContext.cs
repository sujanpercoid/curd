using curd_employee.Models;
using Microsoft.EntityFrameworkCore;

namespace curd_employee.Data
{
  public class DatabaseContext :DbContext
  {
    public DatabaseContext(DbContextOptions opts):base(opts)
    {

    }
    public DbSet<Employee> Employees { get; set; }
  }
}
