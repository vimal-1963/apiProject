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

        public Task addorupdateroom(Room room, string roomId, string hotelId)
        {
            throw new NotImplementedException();
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

        public Task<string> deleteRoom(string id)
        {
            throw new NotImplementedException();
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
