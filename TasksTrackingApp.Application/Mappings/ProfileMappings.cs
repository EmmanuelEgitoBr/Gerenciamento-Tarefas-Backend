using AutoMapper;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Application.UserCQ.Commands;
using TasksTrackingApp.Domain.Entities;

namespace TasksTrackingApp.Application.Mappings
{
    public class ProfileMappings : Profile
    {
        public ProfileMappings()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(x => x.RefreshToken, x => x.MapFrom(x => GenerateGuid()))
                .ForMember(x => x.RefreshTokenExpirationTime, x => x.MapFrom(x => GenerateExpirationTime()))
                .ForMember(x => x.PasswordHash, x => x.MapFrom(x => x.Password));
            
            CreateMap<User, UserDto>().ForMember(x => x.Token, x => x.MapFrom(x => GenerateGuid()));
        }

        private string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        private DateTime GenerateExpirationTime()
        {
            return DateTime.Now.AddDays(5);
        }
    }
}
