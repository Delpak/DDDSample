namespace SAMA.FrameWork.Common.Notifications
{
    public interface INotificationPublisher
    {
        void PublishNotifications();

        bool InternalOnlyTestConfirmation();
    }
}
