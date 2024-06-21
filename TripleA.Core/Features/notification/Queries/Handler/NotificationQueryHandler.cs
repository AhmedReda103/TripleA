using AutoMapper;
using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.Question.Queries.Model;
using TripleA.Data.Entities;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.notification.Queries.Handler
{
    public class NotificationQueryHandler : ResponseHandler,
                                        IRequestHandler<GetNotificationsByIdQuery, Response<List<Notification>>>
    {

        private readonly IMapper mapper;
        private readonly INotificationService notificationService;

        public NotificationQueryHandler(IMapper mapper,
                                    INotificationService notificationService)
        {
            this.mapper = mapper;
            this.notificationService = notificationService;
        }

        public async Task<Response<List<Notification>>> Handle(GetNotificationsByIdQuery request, CancellationToken cancellationToken)
        {
            var notifications = await notificationService.GetNotificationsForAsker(request.AskerId);
            if (notifications != null)
            {
                return Success(notifications);
            }
            return NotFound<List<Notification>>("there is no notification now ");
        }
    }
}
