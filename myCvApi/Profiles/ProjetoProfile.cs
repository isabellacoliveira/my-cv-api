using AutoMapper;
using myCvApi.Data;
using myCvApi.Models;

namespace myCvApi.Profiles;

public class ProjetoProfile : Profile
{
    public ProjetoProfile()
    {
        CreateMap<CreateProjetoDto, Projeto>(); 
        CreateMap<UpdateProjetoDto, Projeto>(); 
        CreateMap<Projeto, UpdateProjetoDto>(); 
        CreateMap<Projeto, ReadProjetoDto>(); 
    }
}