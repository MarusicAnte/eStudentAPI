using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eStudent.Models;
using eStudent.Interfaces;

namespace eStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<List<Role>> GetAllRoles() 
        {
            return await _roleService.GetAllRoles();
        }
    }
}
