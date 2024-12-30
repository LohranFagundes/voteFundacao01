using AppVote01.Dtos;
using AutoMapper;
using AppVote01.Models;

namespace AppVote01.Profiles
{
    public class CandidatoProfile : Profile
    {
        public CandidatoProfile()
        {
            CreateMap<Candidato, CandidatoDto>();
            CreateMap<CandidatoDto, Candidato>();
            CreateMap<CandidatoCreateDto, Candidato>();
            CreateMap<CandidatoUpdateDto, Candidato>();
        }
    }
}