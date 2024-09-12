using AutoMapper;
using CaseStudy.DTO.LoginDto;
using CaseStudy.DTO.RegisterDto;
using CaseStudy.EntityLayer.Concrete;

namespace CaseStudy.WEBUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateNewUserDto,AppUser>().ReverseMap();

            CreateMap<LoginUserDto,AppUser>().ReverseMap(); 
        }
    }
}
