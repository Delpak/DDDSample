using System;
using System.Collections.Generic;

namespace SAMA.Framework.Common.Helpers.Domain
{
    public abstract class DomainEvent
    {
        public DomainEvent()
        {
            Created = DateTime.Now;
            Args = new Dictionary<string, object>();
        }

        public string Type => GetType().Name;

        public DateTime Created { get; }

        public Dictionary<string, object> Args { get; }

        public string CorrelationID { get; set; }

        public abstract void Flatten();
    }
}