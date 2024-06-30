using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface INotificationService
    {
        public Task<List<Notification>> GetNotificationsForAsker(string userId);
        public Task<string> addNotificationAsync(Notification notification);
        public Task<string> UpdateReadNotificationAsync();

    }
}
