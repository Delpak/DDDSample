﻿using System;

namespace SAMA.XSolution.Domain.Exceptions
{
    public class EntityNotFoundException:Exception
    {
        public EntityType Entity { get; private set; }
        public Guid EntityId { get; private set; }

        public EntityNotFoundException(EntityType entity, Guid entityId)
        {
            Entity = entity;
            EntityId = entityId;
        }

        public enum EntityType
        {
            Customer,
            Order
            
        }
    }
}
