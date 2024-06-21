using Microsoft.EntityFrameworkCore;
using TripleA.Data.Entities;
using TripleA.Infrustructure.Abstractions;
using TripleA.Infrustructure.Context;
using TripleA.Infrustructure.InfrastructureBases;

namespace TripleA.Infrustructure.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly DbSet<Notification> _Notifications;
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
            _Notifications = context.Set<Notification>();
        }
    }
}
