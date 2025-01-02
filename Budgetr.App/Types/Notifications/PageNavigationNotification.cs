using System.Windows.Controls;

namespace Budgetr.App.Types.Notifications
{
    public class PageNavigationNotification : NotificationBase
    {
        public Page From { get; init; }
        public Page To { get; init; }
        public PageNavigationNotification(Page from, Page to) : base()
        {
            From = from;
            To = to;
        }
    }
}
