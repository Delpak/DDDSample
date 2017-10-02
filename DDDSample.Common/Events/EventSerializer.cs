using System;
using DDDSample.Common.Domain.Model;
using Newtonsoft.Json;

namespace DDDSample.Common.Events
{
    public class EventSerializer
    {
        readonly static Lazy<EventSerializer> instance = new Lazy<EventSerializer>(() => new EventSerializer(), true);

        public static EventSerializer Instance
        {
            get { return instance.Value; }
        }

        public EventSerializer(bool isPretty = false)
        {
            this.isPretty = isPretty;
        }

        readonly bool isPretty;

        public T Deserialize<T>(string serialization)
        {
            return JsonConvert.DeserializeObject<T>(serialization);
        }

        public object Deserialize(string serialization, Type type)
        {
            return JsonConvert.DeserializeObject(serialization, type);
        }

        public string Serialize(IDomainEvent domainEvent)
        {
            return JsonConvert.SerializeObject(domainEvent, this.isPretty ? Formatting.Indented : Formatting.None);
        }
    }
}
