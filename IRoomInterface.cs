namespace Api_Project
{
    public interface IRoomInterface
    {
        //function to list all rooms
        Task<List<Room>> getAllAvailableRooms();
        //function to add a room
        Task addRoom(Room room, string hotelId);
        //function to list room by id
        Task<Room> getRoomById(string id);
        //function to delete room by id
        Task<String> deleteRoom(string id, string hotelId);
        //function to add or update room
        Task addorupdateroom(Room room, string roomId, string hotelId);
        //function to perform patch request for room
        Task<Room> patchRoom(Room room, string id);
    }
}
