using AppVote01.Data.Dtos;
using AutoMapper;
using AppVote01.Models;

namespace AppVote01.Profiles
{
    public class UserProfile : Profile

    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}