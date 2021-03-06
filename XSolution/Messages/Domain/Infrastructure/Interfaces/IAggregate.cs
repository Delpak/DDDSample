﻿using System;
using System.Collections;

namespace BoundedContext.Domain.Model.Infrastructure.Interfaces
{
    public interface IAggregate
    {
        void ApplyEvent(object e);
        ICollection GetUncommittedEvents();
        void ClearUncommittedEvents();
    }


    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
}
