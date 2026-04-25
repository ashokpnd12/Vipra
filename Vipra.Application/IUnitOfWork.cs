using System;
using System.Collections.Generic;
using System.Text;
using Vipra.Domain.Entities;

namespace Vipra.Application
{
    public interface IUnitOfWork
    {
        IRepository<Panditji> Panditjis { get; }
        IRepository<Yajman> Yajmans { get; }

        Task<int> SaveAsync();
    }
}
