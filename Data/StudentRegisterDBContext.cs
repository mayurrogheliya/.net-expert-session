using expertsession.Models;
using Microsoft.EntityFrameworkCore;

namespace expertsession.Data
{
    public class StudentRegisterDBContext : DbContext
    {
        public StudentRegisterDBContext(DbContextOptions options) : base(options)
        {
        }

        // it create StudentRegister table
        public DbSet<StudentRegister> StudentRegister { get; set; }
        public DbSet<StudentRegister> TestNewStudent { get; set; }
    }
}
    