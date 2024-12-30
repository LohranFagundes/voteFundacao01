using AppVote01.Dtos;
using AutoMapper;
using AppVote01.Models;

namespace AppVote01.Profiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<Log, LogDto>();
            CreateMap<LogDto, Log>();
            CreateMap<LogCreateDto, Log>();
        }
    }
}