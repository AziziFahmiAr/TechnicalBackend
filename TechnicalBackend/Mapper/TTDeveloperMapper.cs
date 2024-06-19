using AutoMapper;
using TechnicalBackend.Entity;
using TechnicalBackend.Models;

namespace TechnicalBackend.Mapper
{
    public class TTDeveloperMapper : Profile
    {
        public TTDeveloperMapper() 
        {
            CreateMap<TTDeveloper, TTDeveloperModel>();
            CreateMap<TTDeveloperHobbies, TTDeveloperHobbiesModel>();
            CreateMap<TTDeveloperSkills, TTDeveloperSkillsModel>();
        }
    }
}
