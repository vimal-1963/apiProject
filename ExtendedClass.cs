using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Project
{
    public class ExtendedClass : IHotelInterface
    {
        public static DynamoDBContext dbContext;
        private readonly IMapper _mapper;

        public ExtendedClass()
        {
            //_mapper = mapperArg;
            dbContext = new DynamoDBContext(Helper.dynamoDBClient);
        }

        

        //referenced function to get all hotels
        public async Task<List<Hotels>> getAllHotels()
        {
            var items = await dbContext.ScanAsync<Hotels>(new List<ScanCondition>()).GetRemainingAsync();
            return items;
        }

        //referenced function to add a hotel
        public async Task addHotel(Hotels hotel)
        {
            await dbContext.SaveAsync(hotel);
        }

        //referenced function to get hotel by id
        public async Task<Hotels> getHotelById(string id)
        {
            var Hotel = await dbContext.LoadAsync<Hotels>(id);
            return Hotel;
        }

        //referenced function to delete hotel by id;
        public async Task<String> deleteHotel(string id)
        {
            var hotel = await dbContext.LoadAsync<Hotels>(id);
            if (hotel != null)
            {
                await dbContext.DeleteAsync<Hotels>(id);
                return "hotel deleted successfully"; // 204 No Content
            }
            else
            {
                return "hotel not found";
            }
        }

        public async Task addorupdatehotel(Hotels hotels, string id)
        {

            var Hotel = await dbContext.LoadAsync<Hotels>(id);
            //var Dtodata = _mapper.Map<HotelDto>(hotels);
            //var RoomDto = _mapper.Map<RoomDto>(hotels.Rooms);
            //if hotel  exist, update hotel 
            if (Hotel != null)
            { 
                Hotel.hotelId = id;
                Hotel.Amenities =hotels .Amenities;
                Hotel.InsuranceAmount = hotels.InsuranceAmount;  
                Hotel.Rooms = hotels.Rooms;
                await addHotel(Hotel);
            }
            else
            {
                Hotels newHotel = new Hotels();
                newHotel.hotelId=id;
                newHotel.Amenities = hotels .Amenities; 
                newHotel.InsuranceAmount = hotels.InsuranceAmount;  
                newHotel.Rooms = hotels .Rooms;
                await addHotel(newHotel);
            }
               
            
        }

        public async Task<Hotels> patchHotel(Hotels hotels, string id)
        {
            var Hotel = await dbContext.LoadAsync<Hotels>(id);
            //var hotelDto = _mapper.Map<Hotels>(hotels);
            if (Hotel == null)
            {
                return Hotel;
            }
            else
            {
                if(hotels.Amenities != null)
                {
                    Hotel.Amenities = hotels.Amenities;
                }
                if(hotels.InsuranceAmount != null)
                {
                    Hotel.InsuranceAmount = hotels.InsuranceAmount; 
                }
                if(hotels.Rooms != null)
                {
                    Hotel.Rooms = hotels.Rooms;
                }

                await addHotel(Hotel);
            }

            return await dbContext.LoadAsync<Hotels>(id);
        }
    }
}
