﻿using System;
using AutoMapper;

namespace SAMA.Framework.Common.WeapsyEvents
{
    public static class EventFactory
    {
        public static dynamic CreateConcreteEvent(object @event)
        {
            Type type = @event.GetType();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap(type, type); });
            IMapper mapper = config.CreateMapper();
            dynamic result = mapper.Map(@event, type, type);
            return result;
        }
    }
}
