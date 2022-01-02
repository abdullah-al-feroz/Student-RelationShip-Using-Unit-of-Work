using EFCoreReltaionShipUnitOfWork.Model;
using Microsoft.EntityFrameworkCore;


namespace EFCoreReltaionShipUnitOfWork.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> Addresses { get; set; }
    }
}
