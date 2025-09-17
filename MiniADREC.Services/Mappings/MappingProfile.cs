using AutoMapper;
using MiniADREC.Domain.Entities;
using MiniADREC.DTO.PermitRequest;
using MiniADREC.DTO.Plot;
using MiniADREC.DTO.Role;
using MiniADREC.DTO.User;

namespace MiniADREC.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles.Select(r => r.Name).ToList()));

            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            // Role Mapping

            CreateMap<Role, RoleDto>();

            // Plot mapping 

            CreateMap<CreatePlotDto, Plot>();
            CreateMap<Plot, PlotDto>();
            CreateMap<PlotDto, Plot>();

            // Permit Mappings

            CreateMap<CreatePermitRequestDto, PermitRequest>();
            CreateMap<PermitRequest, PermitRequestDto>();
        }
    }
}
