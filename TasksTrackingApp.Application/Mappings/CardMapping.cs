using AutoMapper;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Domain.Entities;

namespace TasksTrackingApp.Application.Mappings
{
    public class CardMapping : Profile
    {
        public CardMapping() 
        {
            CreateMap<Card, CardDto>();
        }
    }
}
