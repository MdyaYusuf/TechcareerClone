using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Techcareer.Models.Dtos.Courses.Requests;
using Techcareer.Service.Abstracts;

namespace Techcareer.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CoursesController(ICourseService _courseService) : ControllerBase
  {
    [HttpGet("getall")]
    public async Task<IActionResult> GetAllAsync()
    {
      var result = await _courseService.GetAllAsync();
      return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateCourseRequest request)
    {
      var result = await _courseService.AddAsync(request);
      return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
      var result = await _courseService.GetByIdAsync(id);
      return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
      var result = await _courseService.RemoveAsync(id);
      return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCourseRequest request)
    {
      var result = await _courseService.UpdateAsync(request);
      return Ok(result);
    }
  }
}
