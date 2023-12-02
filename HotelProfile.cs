using AutoMapper;

namespace Api_Project
{
    public class HotelProfile : Profile
    {
        public HotelProfile() {
            CreateMap<Hotels, HotelDto>();
            CreateMap<HotelDto, Hotels>();
            CreateMap<Room, RoomDto>();
            CreateMap<RoomDto, Room>();
        }
    }
}
