using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interface.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [Route ("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // método para selecionar todos os registros no banco
        [HttpGet]

        public async Task<ActionResult> GetAll([FromServices] IUserService service)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState); 
            }
            try {
                return Ok (await service.GetAll ());
            }
            catch (ArgumentException e){
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}