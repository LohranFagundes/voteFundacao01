using AppVote01.Data.Dtos;
using AppVote01.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AppVote01.Models;

namespace AppVote01.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {

        private UserService _userService;
       

        public UserController(UserService cadastroService)
        {
            _userService= cadastroService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            await _userService.Cadastra(dto);

            return Ok("Usuário Cadastrado");


        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(LoginUserDto dto)
        //{
        //   var token = await _userService.Login(dto);
        //    return Ok(token);

        //}


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            var token = await _userService.Login(dto);
            return Ok(token);

        }
    }
}
