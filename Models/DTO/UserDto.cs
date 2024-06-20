namespace eStudent.Models.DTO
{
    public class UserDto
    {
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ImageURL { get; set; }
    }
}
