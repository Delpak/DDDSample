﻿using System;
using System.Collections.Generic;
using SAMA.Core;
using SAMA.Framework.Common.Domain.Model;

namespace SAMA.Framework.Common.Notifications
{
    [Serializable]
    public class Notification : ValueObject
    {
        public Notification(long notificationId, IDomainEvent domainEvent)
        {
            AssertionConcern.AssertArgumentNotNull(domainEvent, "The event is required.");

            this.notificationId = notificationId;
            this.domainEvent = domainEvent;
            this.occurredOn = domainEvent.OccurredOn;
            this.version = domainEvent.Version;
            this.typeName = domainEvent.GetType().FullName;
        }

        readonly long notificationId;
        readonly IDomainEvent domainEvent;
        readonly DateTime occurredOn;
        readonly string typeName;
        readonly int version;

        public TEvent GetEvent<TEvent>() where TEvent : IDomainEvent
        {
            return (TEvent)this.domainEvent;
        }

        public long NotificationId
        {
            get { return this.notificationId; }
        }

        public DateTime OccurredOn
        {
            get { return this.occurredOn; }
        }

        public int Version
        {
            get { return this.version; }
        }

        public string TypeName
        {
            get { return this.typeName; }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.notificationId;
        }
    }
}
