namespace eStudent.Models.DTO
{
    public class CreateUserDto
    {
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ImageURL { get; set; }
    }
}
