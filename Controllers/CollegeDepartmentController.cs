using eStudent.Data;
using eStudent.Interfaces;
using eStudent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeDepartmentController : BaseController
    {
        private readonly ICollegeDepartmentService _collegeDepartmentService;

        public CollegeDepartmentController(ICollegeDepartmentService collegeDepartmentService) 
        {
            _collegeDepartmentService = collegeDepartmentService;
        }


        [HttpGet]
        public async Task<List<CollegeDepartment>> GetAllCollegeDepartments()
        {
            return await _collegeDepartmentService.GetAllCollegeDepartments();
        }


        [HttpGet("{id}")]
        public async Task<CollegeDepartment> GetCollegeDepartmentById(int id)
        {
            return await _collegeDepartmentService.GetCollegeDepartmentById(id);
        }


        [HttpPost]
        public async Task<CollegeDepartment> CreateNewCollegeDepartment(CollegeDepartment collegeDepartment)
        {
            return await _collegeDepartmentService.CreateNewCollegeDepartment(collegeDepartment);
        }


        [HttpPatch]
        public async Task<CollegeDepartment> UpdateCollegeDepartment(CollegeDepartment collegeDepartment)
        {
            return await _collegeDepartmentService.UpdateCollegeDepartment(collegeDepartment);        
        }


        [HttpDelete("{id}")]
        public async Task<CollegeDepartment> DeleteCollegeDepartmentById(int id) 
        {
            return await _collegeDepartmentService.DeleteCollegeDepartmentById(id);
        }
    }
}
