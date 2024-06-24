using eStudent.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eStudent.Models;
using eStudent.Models.DTO;

namespace eStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : BaseController
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }


        [HttpGet]
        public async Task<List<Subject>> GetAllSubjects() 
        {
            return await _subjectService.GetAllSubjects();
        }


        [HttpGet("{id}")]
        public async Task<Subject> GetSubjectById([FromRoute] int id)
        {
            return await _subjectService.GetSubjectById(id);
        }


        [HttpPost]
        public async Task<Subject> CreateNewSubject([FromBody] SubjectDto subjectDto)
        {
            return await _subjectService.CreateNewSubject(subjectDto);
        }


        [HttpPatch("{id}")]
        public async Task<Subject> UpdateSubjectById([FromRoute] int id, [FromBody] SubjectDto subjectDto) 
        {
            return await _subjectService.UpdateSubjectById(id, subjectDto);
        }


        [HttpDelete("{id}")]
        public async Task<Subject> DeleteSubjectById(int id) 
        {
            return await _subjectService.DeleteSubjectById(id);
        }
    }
}
