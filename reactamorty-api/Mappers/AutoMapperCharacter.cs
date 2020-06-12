using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using reactamorty_api.Domains;
using reactamorty_api.DTOs;
using reactamorty_api.Models;

namespace reactamorty_api.Mappers
{
    public class AutoMapperCharacter : Profile
    {
        public AutoMapperCharacter()
        {
            CreateMap<List<CharacterResult>, CharactersDto>()
                .ForPath(dest => dest.Info.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.ToList()));
        }
    }
}