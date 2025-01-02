namespace Budgetr.App.Types.Notifications
{
    public abstract class NotificationBase
    {
        public DateTime NotifiedAt { get; init; }
        public virtual bool HandleOnce => true;

        public NotificationBase()
        {
            NotifiedAt = DateTime.UtcNow;
        }
    }
}
