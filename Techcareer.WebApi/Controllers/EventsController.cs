using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Techcareer.Models.Dtos.Events.Requests;
using Techcareer.Service.Abstracts;

namespace Techcareer.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EventsController(IEventService _eventService) : ControllerBase
  {
    [HttpGet("getall")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllAsync()
    {
      var result = await _eventService.GetAllAsync();
      return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateEventRequest request)
    {
      var result = await _eventService.AddAsync(request);
      return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
      var result = await _eventService.RemoveAsync(id);
      return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEventRequest request)
    {
      var result = await _eventService.UpdateAsync(request);
      return Ok(result);
    }
  }
}
