using AutoMapper;
using IdeaSoft.Test.Api.Domain;
using IdeaSoft.Test.Api.Models.Dtos;
namespace IdeaSoft.Test.Api.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<SavePersonDto, Person>();
            CreateMap<Person, UpdatePersonDto>();
            CreateMap<Person, SearchPersonDto>();
        }
    }
}
