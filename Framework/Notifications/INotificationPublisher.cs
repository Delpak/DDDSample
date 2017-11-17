namespace SAMA.Framework.Common.Notifications
{
    public interface INotificationPublisher
    {
        void PublishNotifications();

        bool InternalOnlyTestConfirmation();
    }
}
