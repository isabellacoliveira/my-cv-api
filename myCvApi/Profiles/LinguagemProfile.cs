using AutoMapper;
using myCvApi.Data;
using myCvApi.Models;

namespace myCvApi.Profiles;

public class LinguagemProfile : Profile
{
    public LinguagemProfile()
    {
        CreateMap<CreateLinguagemDto, Linguagem>(); 
        CreateMap<UpdateLinguagemDto, Linguagem>(); 
        CreateMap<Linguagem, UpdateLinguagemDto>(); 
        CreateMap<Linguagem, ReadLinguagemDto>(); 
    }
}