using EFCoreReltaionShipUnitOfWork.GenericRepo.InfraStructure;
using EFCoreReltaionShipUnitOfWork.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreReltaionShipUnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneToOneController : ControllerBase
    {
        private readonly IStudent<Student> _studentRepo;
        private readonly IStudent<StudentAddress> _studentAddress;
        

        public OneToOneController(IStudent<Student> studentRepo, IStudent<StudentAddress> studentAddress)
        {
            _studentRepo = studentRepo;
            _studentAddress = studentAddress;
        }


       [HttpGet("Student")]
        public async Task<ActionResult<List<Student>>> GetAllStudent()
        {
            try
            {
                var student = await _studentRepo.GetAll();
                return Ok (student);
            }
            catch (System.Exception)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError);
            }   
        }

        [HttpGet("GetAllStudent")]
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            try
            {
                var item = await _studentRepo.GetAllItem();
                return Ok(item);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }    
        }

        [HttpPost("Add Student")]
        public async Task<ActionResult<List<Student>>> Post(Student student)
        {
            try 
            {
                var item = await _studentRepo.AddItem(student);
                return Ok(item);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }   
        }

        [HttpPost("AddAddress")]
        public async Task<ActionResult<List<StudentAddress>>> PostAddress(StudentAddress address)
        {
            try
            {
                var item = await _studentAddress.AddItem(address);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }  
        }

        [HttpDelete("DeleteStudent")]
        public async Task <ActionResult<Student>> DeleteStudent(int student)
        {
            try
            {
                var item = await _studentRepo.DeleteStudent(student);
                if (item == null)
                {
                    return BadRequest("Item Not found");
                }
                else
                {
                    return Ok(item);
                }
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

    }
}
