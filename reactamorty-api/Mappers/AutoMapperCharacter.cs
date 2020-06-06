using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using reactamorty_api.Domains;
using reactamorty_api.Models;

namespace reactamorty_api.Mappers
{
    public class AutoMapperCharacter : Profile
    {
        public AutoMapperCharacter()
        {
            CreateMap<Task<List<Character>>, CharacterInfo>()
                .ForMember(o => o.Count, b => b.MapFrom(z => z.Result.Count));
        }
    }
}