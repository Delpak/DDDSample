﻿namespace SAMA.Framework.Common.Notifications
{
    public class NotificationLogInfo
    {
        public NotificationLogInfo(NotificationLogId notificationLogId, long totalLogged)
        {
            this.notificationLogId = notificationLogId;
            this.totalLogged = totalLogged;
        }

        readonly NotificationLogId notificationLogId;

        public NotificationLogId NotificationLogId
        {
            get { return notificationLogId; }
        }

        readonly long totalLogged;

        public long TotalLogged
        {
            get { return totalLogged; }
        } 

    }
}
