using eStudent.Services;

namespace eStudent.Models.DTO
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Semester { get; set; }
        public int? ECTS { get; set; }
        public string? Description { get; set; }
        public List<UserDto>? Users { get; set; }
        public List<CollegeDepartmentDto>? CollegeDepartments { get; set; }

        public static readonly Func<Subject, SubjectDto> Select
            = x => new()
            {
                Id = x.Id,
                Name = x.Name,
                Semester = x.Semester,
                ECTS = x.ECTS,
                Description = x.Description,
                Users = x.Users?.Select(UserDto.Select).ToList(),
                CollegeDepartments = x.Departments?.Select(CollegeDepartmentDto.Select).ToList()
            };

        public Subject ToDomain()
            => new()
            {
                Id = Id,
                Name = Name,
                Semester = Semester,
                ECTS = ECTS,
                Description = Description,
                Users = Users?.Select(x => x.ToDomain()).ToList(),
                Departments = CollegeDepartments?.Select(x => x.ToDomain()).ToList()
            };
    }
}
