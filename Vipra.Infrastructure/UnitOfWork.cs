using System;
using System.Collections.Generic;
using System.Text;
using Vipra.Application;
using Vipra.Domain.Entities;

namespace Vipra.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRepository<Panditji> Panditjis { get; }
        public IRepository<Yajman> Yajmans { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Panditjis = new Repository<Panditji>(_context);
            Yajmans = new Repository<Yajman>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
