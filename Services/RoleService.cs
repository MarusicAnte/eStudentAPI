using eStudent.Data;
using eStudent.Interfaces;
using eStudent.Models;
using Microsoft.EntityFrameworkCore;

namespace eStudent.Services
{
    public class RoleService : IRoleService
    {

        private readonly ApplicationDBContext _dbContext;

        public RoleService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            var roles = await _dbContext.Roles.ToListAsync();

            if (roles is null) 
            {
                throw new Exception("Roles doesn't exist.");
            }

            return roles;
        }

    }
}
