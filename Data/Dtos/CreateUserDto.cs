using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AppVote01.Data.Dtos
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; } // Add this line
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
