namespace eStudent.Models.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ImageURL { get; set; }

        public List<SubjectDto>? Subjects { get; set; }

        public static readonly Func<User, UserDto> Select
            = x => new()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Password = x.Password,
                ImageURL = x.ImageURL ?? null,
                RoleId = x.RoleId,
                Role= x.Role,
                Subjects = x.Subjects?.Select(SubjectDto.Select).ToList(),
            };

        public User ToDomain()
           => new()
           {
               Id = Id,
               FirstName = FirstName,
               LastName = LastName,
               Email = Email,
               Password = Password,
               RoleId = RoleId,
               ImageURL= ImageURL,
               Subjects = Subjects?.Select(x => x.ToDomain()).ToList(),
           };
    }
}
