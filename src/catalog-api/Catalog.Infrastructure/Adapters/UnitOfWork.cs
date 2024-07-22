﻿using Catalog.Domain.Ports;
using Catalog.Infrastructure.DataSource;

namespace Catalog.Infrastructure.Adapters
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public async Task SaveAsync(CancellationToken? cancellationToken = null)
        {
            var token = cancellationToken ?? new CancellationTokenSource().Token;

            _context.ChangeTracker.DetectChanges();

            await _context.SaveChangesAsync(token);
        }
    }
}
