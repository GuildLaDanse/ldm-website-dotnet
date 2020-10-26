using System;
using LaDanse.Application.Events.Models;
using MediatR;

namespace LaDanse.Application.Events.Queries.GetEvent
{
    public class GetEventQuery : IRequest<Event>
    {
        public GetEventQuery(Guid eventId)
        {
            EventId = eventId;
        }
        
        public Guid EventId { get; }
    }
}