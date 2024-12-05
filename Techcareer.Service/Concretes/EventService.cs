using AutoMapper;
using Core.Responses;
using Techcareer.DataAccess.Abstracts;
using Techcareer.Models.Dtos.Events.Requests;
using Techcareer.Models.Dtos.Events.Responses;
using Techcareer.Models.Entities;
using Techcareer.Service.Abstracts;
using Techcareer.Service.Rules;

namespace Techcareer.Service.Concretes;

public class EventService(IEventRepository _eventRepository, IMapper _mapper, EventBusinessRules _businessRules) : IEventService
{
  public async ValueTask<ReturnModel<EventResponse>> AddAsync(CreateEventRequest request)
  {
    await _businessRules.IsTitleUnique(request.Title);

    Event createdEvent = _mapper.Map<Event>(request);
    await _eventRepository.AddAsync(createdEvent);
    EventResponse response = _mapper.Map<EventResponse>(createdEvent);

    return new ReturnModel<EventResponse>()
    {
      Success = true,
      Message = "Etkinlik eklendi.",
      Data = response,
      StatusCode = 201
    };
  }

  public async Task<ReturnModel<List<EventResponse>>> GetAllAsync()
  {
    List<Event> events = await _eventRepository.GetAllAsync();
    List<EventResponse> responseList = _mapper.Map<List<EventResponse>>(events);

    return new ReturnModel<List<EventResponse>>()
    {
      Success = true,
      Message = "Etkinlik listesi başarılı bir şekilde getirildi.",
      Data = responseList,
      StatusCode = 200
    };
  }

  public async ValueTask<ReturnModel<EventResponse>> GetByIdAsync(int id)
  {
    await _businessRules.IsEventExistAsync(id);

    Event? eventVariable = await _eventRepository.GetByIdAsync(id);
    EventResponse? response = _mapper.Map<EventResponse>(eventVariable);

    return new ReturnModel<EventResponse>()
    {
      Success = true,
      Message = $"{id} numaralı etkinlik başarılı bir şekilde getirildi.",
      Data = response,
      StatusCode = 200
    };
  }

  public async Task<ReturnModel<NoData>> RemoveAsync(int id)
  {
    await _businessRules.IsEventExistAsync(id);

    Event eventVariable = await _eventRepository.GetByIdAsync(id);
    _eventRepository.Delete(eventVariable);

    return new ReturnModel<NoData>()
    {
      Success = true,
      Message = "Etkinlik silindi.",
      StatusCode = 204
    };
  }

  public async Task<ReturnModel<NoData>> UpdateAsync(UpdateEventRequest request)
  {
    await _businessRules.IsEventExistAsync(request.Id);

    Event existingEvent = await _eventRepository.GetByIdAsync(request.Id);

    existingEvent.Id = existingEvent.Id;
    existingEvent.Title = request.Title;
    existingEvent.Description = request.Description;
    existingEvent.Tag = request.Tag;
    existingEvent.Image = request.Image;
    existingEvent.Deadline = request.Deadline;

    _eventRepository.Update(existingEvent);

    return new ReturnModel<NoData>()
    {
      Success = true,
      Message = $"{request.Id} numaralı etkinlik güncellendi.",
      StatusCode = 204
    };
  }
}
