using AutoMapper;

namespace reactamorty_api.Mappers 
{  
    public class AutoMapperCharacter : Profile  
    {  
        public AutoMapperCharacter()
        {
            CreateMap<StudentDTO, Student>();
        }  
    }  
}  