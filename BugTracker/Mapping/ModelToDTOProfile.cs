using AutoMapper;
using BugTracker.Api.Models;
using BugTracker.Core.Entities;

namespace BugTracker.Api.Mapping
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            //CreateMap<Bug, BugDTO>()
            CreateMap<Bug, BugDTO>();


            CreateMap<BugDTO, Bug>();
                
        }
    }
}
