namespace Budgetr.App.Types.Events
{
    public class EventBase<TSender, TReceiver> where TSender : class where TReceiver : class
    {
        TSender Sender { get; set; }
        TReceiver? Receiver { get; set; }
        DateTime RaisedAt { get; set; }
        bool Handled { get; set; }

        public EventBase(TSender sender, TReceiver? receiver = null)
        {
            Sender = sender;
            Receiver = receiver;
            RaisedAt = DateTime.Now;
            Handled = false;
        }
    }
}
