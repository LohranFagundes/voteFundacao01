using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace AppVote01.Data.Dtos
{
    public class LoginUserDto
    {
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
