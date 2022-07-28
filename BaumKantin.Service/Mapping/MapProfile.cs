using AutoMapper;
using BaumKantin.Core;
using BaumKantin.Core.DTOs;
using BaumKantin.Core.Models;

namespace BaumKantin.Service.Mapping
{
    public class MapProfile:Profile 
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CustomerRoomDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();
            
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Room,RoomCustomersDTO>().ReverseMap();
            CreateMap<Room,UpdateRoomDTO>().ReverseMap();
            
            CreateMap<ImageModel,ByteImageDTO>().ReverseMap();
            CreateMap<ImageModel,FormFileImageDTO>().ReverseMap();
            CreateMap<ImageModel, CustomerRoomDTO>().ReverseMap();
        }
    }
}

