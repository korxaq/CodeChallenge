using System.Globalization;
using AutoMapper;
using CodeChallenge.Common.Dto;
using CodeChallenge.Common.MagicValues;

namespace CodeChallenge.BLL.Mappings
{
    public class UserProjectsProfile : Profile
    {
        public UserProjectsProfile()
        {
            CreateMap<UserProjectDto, UserProjectCalculatedDto>()
                .ForMember(upcd => upcd.StartDate, opt => opt.MapFrom(src => src.Project.StartDate.ToString(CultureInfo.InvariantCulture)))
                .ForMember(upcd => upcd.TimeToStart,
                    opt => opt.MapFrom(src =>
                        (src.Project.StartDate - src.AssignedDate).Days > 0
                            ? (src.Project.StartDate - src.AssignedDate).Days.ToString()
                            : Constants.STARTED))
                .ForMember(upcd => upcd.EndDate, opt => opt.MapFrom(src => src.Project.EndDate.ToString(CultureInfo.InvariantCulture)))
                .ForMember(upcd => upcd.Credits, opt => opt.MapFrom(src => src.Project.Credits))
                .ForMember(upcd => upcd.Status, opt => opt.MapFrom(src => src.IsActive ? Constants.ACTIVE : Constants.INACTIVE))
                ;
        }
    }
}
