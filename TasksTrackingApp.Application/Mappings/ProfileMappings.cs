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
                .ForMember(x => x.RefreshToken, x => x.AllowNull())
                .ForMember(x => x.RefreshTokenExpirationTime, x => x.MapFrom(x => GenerateExpirationTime()))
                .ForMember(x => x.PasswordHash, x => x.AllowNull());
            
            CreateMap<User, UserDto>().ForMember(x => x.Token, x => x.AllowNull());
        }

        private string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        private DateTime GenerateExpirationTime()
        {
            return DateTime.Now.AddHours(3);
        }
    }
}
