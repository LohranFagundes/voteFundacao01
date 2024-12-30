using AppVote01.Dtos;
using AutoMapper;
using AppVote01.Models;

namespace AppVote01.Profiles
{
    public class VotoProfile : Profile
    {
        public VotoProfile()
        {
            CreateMap<Voto, VotoDto>();
            CreateMap<VotoDto, Voto>();
            CreateMap<VotoCreateDto, Voto>();
        }
    }
}