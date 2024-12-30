using AppVote01.Data.Dtos;
using AutoMapper;
using AppVote01.Dtos;
using AppVote01.Models;

namespace AppVote01.Models
{
    public class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<Cargo, CargoDto>();
            CreateMap<CargoDto, Cargo>();
            CreateMap<CargoCreateDto, Cargo>(); // Updated reference
            CreateMap<CargoUpdateDto, Cargo>(); // Updated reference
        }
    }
}