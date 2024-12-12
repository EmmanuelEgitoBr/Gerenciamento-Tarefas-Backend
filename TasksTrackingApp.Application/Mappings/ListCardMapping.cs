using AutoMapper;
using TasksTrackingApp.Application.DTOs;
using TasksTrackingApp.Domain.Entities;

namespace TasksTrackingApp.Application.Mappings
{
    public class ListCardMapping : Profile
    {
        public ListCardMapping()
        {
            CreateMap<ListCard, ListCardDto>();
        }
    }
}
