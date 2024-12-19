using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public UnitOfWork(ApplicationDBContext context)
            => _context = context;

        async ValueTask IAsyncDisposable.DisposeAsync()
            => await _context.DisposeAsync();

        public DbContext GetDbContext()
            => _context;

        public async Task SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                throw new ServerException(SAVECHANGE_ERROR.SAVE_FAILED);
            }
        }
    }
}
