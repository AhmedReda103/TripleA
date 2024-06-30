using AutoMapper;
using MediatR;
using TripleA.Core.Bases;
using TripleA.Core.Features.notification.Commands.Models;
using TripleA.Service.Abstracts;

namespace TripleA.Core.Features.notification.Commands.Handler
{
    public class NotificationCommandHandler : ResponseHandler,
        IRequestHandler<UpdateNotificationCommand, Response<string>>
    {

        private readonly IMapper mapper;
        private readonly INotificationService notificationService;

        public NotificationCommandHandler(
            IMapper mapper,
            INotificationService notificationService)
        {
            this.mapper = mapper;
            this.notificationService = notificationService;
        }

        public async Task<Response<string>> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var result = await notificationService.UpdateReadNotificationAsync();
            if (result == "Updated")
            {
                return Success("");
            }
            else
            {
                return BadRequest<string>();
            }
        }
    }
}
