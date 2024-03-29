﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void RollBack();
        Task SaveChanges();
        void BeginTransaction();
        void ClearTracking();
    }
}
