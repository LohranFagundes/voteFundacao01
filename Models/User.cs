using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppVote01.Models
{
    public class User : IdentityUser
    {
        public bool EmailConfirmed { get; set; } = false;
        public string Name   {get; set;}
        public string CPF { get; set; }

        [Required]
        public override string Email { get; set; }
        public User() : base() { }

    }
}