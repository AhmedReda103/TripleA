using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork unitOfWork;

        public NotificationService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<string> addNotificationAsync(Notification notification)
        {
            try
            {
                await unitOfWork.Notifications.AddAsync(notification);
                await unitOfWork.SaveChangesAsync();
                return "Added";

            }
            catch (Exception ex)
            {
                return "adding Notification Failed " + ex.Message;
            }

        }

        public async Task<List<Notification>> GetNotificationsForAsker(string userId)
        {
            var notifications = await unitOfWork.Notifications.GetAllAsync();
            return notifications.Where(n => n.UserId == userId).OrderByDescending(n => n.CreatedIn).ToList();
        }
    }
}
