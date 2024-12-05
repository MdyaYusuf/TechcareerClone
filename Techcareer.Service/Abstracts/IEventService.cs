using Core.Responses;
using Techcareer.Models.Dtos.Events.Requests;
using Techcareer.Models.Dtos.Events.Responses;

namespace Techcareer.Service.Abstracts;

public interface IEventService
{
  Task<ReturnModel<List<EventResponse>>> GetAllAsync();
  ValueTask<ReturnModel<EventResponse>> GetByIdAsync(int id);
  ValueTask<ReturnModel<EventResponse>> AddAsync(CreateEventRequest request);
  Task<ReturnModel<NoData>> UpdateAsync(UpdateEventRequest request);
  Task<ReturnModel<NoData>> RemoveAsync(int id);
}
