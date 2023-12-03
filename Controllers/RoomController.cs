using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IMapper _mapper;
        IRoomInterface roomInterface;

        public RoomController(ILogger<RoomController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            roomInterface = new ExtendedClass2();
        }

        [HttpGet("getAllRooms")]
        public async Task<ActionResult<IEnumerable<Room>>> ListRooms()
        {
            try
            {
                var items = await roomInterface.getAllAvailableRooms();
                var itemsDto = _mapper.Map<List<RoomDto>>(items);
                return Ok(itemsDto);

            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getRoomById/{id}")]
        public async Task<ActionResult<Room>> GetroomById(string id)
        {
            try
            {
                var items = await roomInterface.getRoomById(id);
                var itemDto = _mapper.Map<RoomDto>(items);
                if (itemDto != null)
                {
                    Console.WriteLine(itemDto);
                    return Ok(itemDto);
                }
                else
                {
                    return NotFound($"Hotel with ID {id} not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("Addroom/{hotelId}")]
        public async Task<IActionResult> AddRoom([FromBody] Room roomlDto, string hotelId)
        {
            try
            {
                var room = _mapper.Map<Room>(roomlDto);
                await roomInterface.addRoom(room, hotelId);
                return Ok($"Room with ID {roomlDto.RoomId} added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("addorupdateroom/{roomId}/{hotelId}")]
        public async Task<IActionResult> AddHotelThroughPut([FromBody] Room roomDto, string roomId, string hotelId)
        {
            try
            {
                await roomInterface.addorupdateroom(roomDto, roomId, hotelId);
                return Ok("updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteRoomById/{roomId}/{hotelId}")]
        public async Task<IActionResult> DeleteRoomById(string roomId, string hotelId)
        {
            try
            {
                String status = await roomInterface.deleteRoom(roomId, hotelId);
                return Ok($"hotel with {roomId} deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




    }


}
