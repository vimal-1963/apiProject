using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;

namespace Api_Project
{
    [DynamoDBTable("Hotels")]
    public class Hotels
    {
        [DynamoDBHashKey]
        public string hotelId { get; set; }

        [DynamoDBProperty("amenities")]
        public List<string> Amenities { get; set; }

        [DynamoDBProperty("hotelName")]
        public string hotelName { get; set; }

        [DynamoDBProperty("insuranceAmount")]
        public string InsuranceAmount { get; set; }

        [DynamoDBProperty("Rooms")]
        public List<Room> Rooms { get; set; }
    }

    public class Room
    {
        [DynamoDBProperty("availability")]
        public bool Availability { get; set; }

        [DynamoDBProperty("bedType")]
        public string BedType { get; set; }

        [DynamoDBProperty("breakFastIncluded")]
        public bool BreakfastIncluded { get; set; }

        [DynamoDBProperty("insuranceNeeded")]
        public bool InsuranceNeeded { get; set; }

        [DynamoDBProperty("noOfBed")]
        public string NoOfBed { get; set; }

        [DynamoDBProperty("noOfOccupants")]
        public string NoOfOccupants { get; set; }

        [DynamoDBProperty("price")]
        public string Price { get; set; }

        [DynamoDBProperty("roomId")]
        public string RoomId { get; set; }
    }
}
