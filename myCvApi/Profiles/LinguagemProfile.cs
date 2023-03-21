using AutoMapper;
using myCvApi.Data;
using myCvApi.Models;

namespace myCvApi.Profiles;

public class LinguagemProfile : Profile
{
    public LinguagemProfile()
    {
        CreateMap<CreateLinguagemDto, Linguagem>(); 
        CreateMap<Linguagem, UpdateLinguagemDto>(); 
        CreateMap<Linguagem, ReadLinguagemDto>()
          .ForMember(linguagemDto => linguagemDto.Projetos,
                    opt => opt.MapFrom(linguagem => linguagem.Projetos));
        CreateMap<UpdateLinguagemDto, Linguagem>(); 
    }
}