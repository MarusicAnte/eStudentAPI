using eStudent.Models;

namespace eStudent.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoles();
    }
}
