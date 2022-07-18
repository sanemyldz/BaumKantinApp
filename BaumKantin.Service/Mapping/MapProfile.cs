using AutoMapper;
using BaumKantin.Core;
using BaumKantin.Core.DTOs;

namespace BaumKantin.Service.Mapping
{
    public class MapProfile:Profile 
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CustomerRoomsDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Room,RoomCustomersDTO>().ReverseMap();
        }
    }
}

