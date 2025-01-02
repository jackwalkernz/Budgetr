namespace Budgetr.App.Types.Notifications
{
    public class PageNavigationResponse
    {
        public bool IsSuccessful { get; init; }
        public DateTime NavigatedAt { get; init; }

        public PageNavigationResponse(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
            NavigatedAt = DateTime.UtcNow;
        }
    }
}
