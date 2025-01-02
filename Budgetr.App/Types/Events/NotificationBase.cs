namespace Budgetr.App.Types.Events
{
    public class NotificationBase<TSender> where TSender : class
    {
        TSender? Sender { get; init; }
        public DateTime NotifiedAt => DateTime.UtcNow;

        public virtual bool HandleOnce => true;

        public NotificationBase() { }
        public NotificationBase(TSender sender)
        {
            Sender = sender;
        }
    }
}
