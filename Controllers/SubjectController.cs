using eStudent.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eStudent.Models;
using eStudent.Models.DTO;
using eStudent.Query;

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
        public async Task<List<Subject>> GetAllSubjects([FromQuery] SubjectQuery subjectQuery)
        {
            return await _subjectService.GetAllSubjects(subjectQuery);
        }


        [HttpGet("{id}")]
        public async Task<Subject> GetSubjectById([FromRoute] int id)
        {
            return await _subjectService.GetSubjectById(id);
        }


        [HttpPost]
        public async Task<Subject> CreateNewSubject([FromBody] SubjectDto subjectDto)
        {
            return await _subjectService.CreateNewSubject(subjectDto.ToDomain());
        }


        [HttpPatch]
        public async Task<Subject> UpdateSubject([FromBody] SubjectDto subjectDto)
        {
            return await _subjectService.UpdateSubject(subjectDto.ToDomain());
        }


        [HttpDelete("{id}")]
        public async Task<Subject> DeleteSubjectById(int id)
        {
            return await _subjectService.DeleteSubjectById(id);
        }
    }
}