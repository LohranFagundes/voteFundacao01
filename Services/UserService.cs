using AppVote01.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AppVote01.Models;

namespace AppVote01.Services
{
    public class UserService
    {
        private IMapper _mapper;

  

        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task Cadastra(CreateUserDto dto)
        {

            User user = _mapper.Map<User>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(user, dto.Password);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuario");
            }
            
            
        }

        public async Task<string> Login(LoginUserDto dto)
        {
            // 1. Buscar usuário pelo CPF
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.CPF == dto.CPF);

            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return null; // Usuário não encontrado ou senha incorreta

            // 2. Gerar token JWT
            var token = _tokenService.GenerateToken(user);
            return token;
        }
    }
}
