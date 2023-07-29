using AutoMapper;
using Bookify.Web.Core.Models;

namespace Bookify.Web.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();

            CreateMap<Category, CreateCategoryViewModel>().ReverseMap();

            CreateMap<Category, EditCategoryViewModel>().ReverseMap();
        }
    }
}
