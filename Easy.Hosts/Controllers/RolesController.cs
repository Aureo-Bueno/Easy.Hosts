using Easy.Hosts.Core.DTOs.Role;
using Easy.Hosts.Core.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Controllers
{
    [Route("api/easyhosts/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RolesController> _logger;
        public RolesController(RoleManager<IdentityRole> roleManager, ILogger<RolesController> logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<IdentityRole> roles = await _roleManager.Roles.ToListAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateRoleDto createRoleDto)
        {
            CreateRoleDtoValidator validator = new CreateRoleDtoValidator();

            ValidationResult validate = await validator.ValidateAsync(createRoleDto);

            if (validate.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = createRoleDto.Name };
                IdentityResult result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Created Role");
                    return Ok();
                }
            }

            return BadRequest(validate.Errors);
        }
    }
}
