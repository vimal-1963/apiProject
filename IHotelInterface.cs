namespace Api_Project
{
    public interface IHotelInterface
    {
        //function to list all hotels
        Task<List<Hotels>> getAllHotels();
        //function to add a hotel
        Task addHotel(Hotels hotels);
        //function to list hotel by id
        Task<Hotels> getHotelById(string id);
        //function to delete hotel by id
        Task<String> deleteHotel(string id);
        //function to add or update hotel
        Task addorupdatehotel(Hotels hotels,string id);
        //function to perform patch request for hotel
        Task<Hotels> patchHotel(Hotels hotels,string id);   
    }
}
