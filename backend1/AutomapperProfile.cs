using AutoMapper;
using backend1.Data.Entity;
using backend1.Models;

namespace backend1
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<ChildEntity, ChildModel>()
                .ReverseMap();
        }
    }
}
