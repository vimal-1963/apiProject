
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Api_Project.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    
    public class HotelDetailsController : ControllerBase
    {
        private readonly ILogger<HotelDetailsController> _logger;
        private readonly IMapper _mapper;
        IHotelInterface hotelInterface;

        public  HotelDetailsController(ILogger<HotelDetailsController> logger, IMapper mapper)
        {
           
            _logger = logger;
            _mapper = mapper;
            hotelInterface = new ExtendedClass();
            
        }

        [HttpGet(Name = "HotelDetails")]
        public async Task<ActionResult<IEnumerable<Hotels>>> ListTables()
        {
            hotelInterface = new ExtendedClass();
            try
            {
                var items = await hotelInterface.getAllHotels();
                var itemsDto = _mapper.Map<List<HotelDto>>(items);
                return Ok(itemsDto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
        [HttpPost(Name ="Addhotel")]
        public async Task<IActionResult> AddHotel([FromBody] Hotels hotelDto)
        {
            try
            {
                var hotel = _mapper.Map<Hotels>(hotelDto);
                await hotelInterface.addHotel(hotel);
                return Ok($"Hotel with ID {hotel.hotelId} added successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
        [HttpGet("GetHotelDetailsById/{id}")]
        public async Task<ActionResult<Hotels>> GetHotelById(string id)
        {
            try
            {
                var hotel = await hotelInterface.getHotelById(id);
                var itemDto = _mapper.Map<HotelDto>(hotel);
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

        
        [HttpDelete("DeleteHotelById/{id}")]
        public async Task<IActionResult> DeleteHotelById(string id)
        {
            try
            {
                String status = await hotelInterface.deleteHotel(id);
                return Ok($"hotel with {id} deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("addorupdatehotel/{id}")]
        public async Task<IActionResult> AddHotelThroughPut([FromBody] Hotels hotelDto, string id)
        {
            try
            {
                await hotelInterface.addorupdatehotel(hotelDto, id);
                return Ok("updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        
        [HttpPatch("patchhotel/{id}")]
        public async Task<IActionResult> UpdateHotelThroughPatch([FromBody] Hotels hotel, string id)
        {
            try
            {
               await hotelInterface.patchHotel(hotel, id);
                return Ok("Hotel patch request successfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        

    }
    
}
