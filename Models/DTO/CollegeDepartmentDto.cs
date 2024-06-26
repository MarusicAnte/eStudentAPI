namespace eStudent.Models.DTO
{
    public class CollegeDepartmentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<SubjectDto>? Subjects { get; set; }
        public List<UserDto>? Users { get; set; }


        public static readonly Func<CollegeDepartment, CollegeDepartmentDto> Select
            = x => new()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Subjects = x.Subjects?.Select(SubjectDto.Select).ToList(),
                Users = x.Users?.Select(UserDto.Select).ToList()
            };


        public CollegeDepartment ToDomain()
            => new()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Subjects = Subjects?.Select(x => x.ToDomain()).ToList(),
                Users = Users?.Select(x => x.ToDomain()).ToList(),
            };
    }
}
