using Microsoft.AspNetCore.Mvc;
using ParamoTech.SatRecruitment.Application.Interface;
using Refit;
using ParamoTech.SatRecruitment.DTO.Users.Request;
using Swashbuckle.AspNetCore.Annotations;

namespace ParamoTech.SatRecruitment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([Body] RequestCreateUser request)
        {
            return Ok(await Task.Run(() => _usersService.CreateUser(request)));
        }
    }
}
