using EFCoreReltaionShipUnitOfWork.Data;
using EFCoreReltaionShipUnitOfWork.GenericRepo.InfraStructure;
using EFCoreReltaionShipUnitOfWork.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreReltaionShipUnitOfWork.GenericRepo.Serivice
{
    public class StudentRepository<T> : IStudent<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> studentContext;

        public StudentRepository(DataContext context)
        {
            _context = context;
            studentContext = _context.Set<T>();
        }
        public async Task<List<T>> AddItem(T t)
        {
            var item = await studentContext.AddAsync(t);
            _context.SaveChanges();
            return await studentContext.ToListAsync();
        }

        public async Task<T> DeleteStudent(int t)
        {
            var students = await studentContext.FindAsync(t);
            studentContext.Remove(students);
            await _context.SaveChangesAsync();
            return students;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            var students = await _context.Students
                .Include(a => a.Address)
                .ToListAsync();
            return (students);
        }

        public async Task<List<T>> GetAllItem()
        {
            return await studentContext.ToListAsync();
        }

        //public async Task<List<StudentAddress>> AddAddress(T t)
        // {
        //     var item = await studentContext.AddAsync(t);
        //     _context.SaveChanges();
        //     return await studentContext.ToListAsync();

        // }
    }

}
