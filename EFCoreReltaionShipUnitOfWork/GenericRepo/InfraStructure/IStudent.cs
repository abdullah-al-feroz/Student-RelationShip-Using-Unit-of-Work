using EFCoreReltaionShipUnitOfWork.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreReltaionShipUnitOfWork.GenericRepo.InfraStructure
{
    public interface IStudent<T>where T : class
    {
        public Task<IEnumerable<Student>> GetAll();
        public Task<List<T>> AddItem(T t);
        public Task<List<T>> GetAllItem();
        public Task<T> DeleteStudent(int t);
    }
}
