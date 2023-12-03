using Amazon.DynamoDBv2.DataModel;
using AutoMapper;

namespace Api_Project
{
    public class ExtendedClass2 : IRoomInterface
    {
        public static DynamoDBContext dbContext;
        private readonly IMapper _mapper;

        public ExtendedClass2()
        {
            dbContext = new DynamoDBContext(Helper.dynamoDBClient);
        }

        public async Task addorupdateroom(Room roomArg, string roomId, string hotelId)
        {
            var Hotel = await dbContext.LoadAsync<Hotels>(hotelId);
            bool status = false;
            foreach (var room in Hotel.Rooms)
            {
                if (room.RoomId == roomId)
                {
                    status = true;
                    room.RoomId = roomId;
                    room.Availability = roomArg.Availability;
                    room.BreakfastIncluded = roomArg.BreakfastIncluded;
                    room.InsuranceNeeded = roomArg.InsuranceNeeded;
                    room.NoOfBed = roomArg.NoOfBed;
                    room.NoOfOccupants = roomArg.NoOfOccupants;
                    room.Price = roomArg.Price;
                    await dbContext.SaveAsync(Hotel);
                }
            }
            if (status != true)
            {
                Hotel.Rooms.Add(roomArg);
                await dbContext.SaveAsync(Hotel);
            }

        }





        public async Task addRoom(Room room, string hotelId)
        {
            var items = await dbContext.ScanAsync<Hotels>(new List<ScanCondition>()).GetRemainingAsync();
            foreach(var item in items) { 
                if(item.hotelId == hotelId)
                {
                    item.Rooms.Add(room);
                }
                await dbContext.SaveAsync(item);
            }
        }

        public async Task<string> deleteRoom(string id, string hotelId)
        {
            var Hotel = await dbContext.LoadAsync<Hotels>(hotelId);
            if (Hotel != null)
            {
                foreach (Room room in Hotel.Rooms)
                {
                    if (room.RoomId == id)
                    {
                        Hotel.Rooms.Remove(room);
                        await new ExtendedClass().addHotel(Hotel);
                        
                    }

                }
                return "Deleted Successfully";
            }
            else
            {
                return "hotel not found";
            }
            
        }

        public async Task<List<Room>> getAllAvailableRooms()
        {
            var items = await dbContext.ScanAsync<Hotels>(new List<ScanCondition>()).GetRemainingAsync();
            var roomsList = new List<Room>();
            foreach(var item in items) { 
                foreach(Room room in item.Rooms)
                {
                    if (room.Availability)
                    {
                        roomsList.Add(room);
                    }
                }
            }
            return roomsList;
        }

        public async Task<Room> getRoomById(string id)
        {
            var items = await dbContext.ScanAsync<Hotels>(new List<ScanCondition>()).GetRemainingAsync();
            foreach(var item in items)
            {
                foreach(Room room in item.Rooms)
                {
                    if (room.RoomId == id)
                    {
                        return room;
                    }
                }
            }
            return new Room();
        }

        public Task<Room> patchRoom(Room room, string id)
        {
            throw new NotImplementedException();
        }
    }
}
