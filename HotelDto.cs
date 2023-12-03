namespace Api_Project
{
    public class HotelDto
    {
        public string hotelId { get; set; }

        public string HotelName { get; set; }
        public List<string> Amenities { get; set; }
        public string InsuranceAmount { get; set; }
        public List<RoomDto> Rooms { get; set; }
    }

    public class RoomDto
    {
        public bool Availability { get; set; }
        public string BedType { get; set; }
        public bool BreakfastIncluded { get; set; }
        public bool InsuranceNeeded { get; set; }
        public string NoOfBed { get; set; }
        public string NoOfOccupants { get; set; }
        public string Price { get; set; }
        public string RoomId { get; set; }
    }
}
