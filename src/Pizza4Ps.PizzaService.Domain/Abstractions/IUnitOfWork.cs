using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Abstractions
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task SaveChangeAsync(CancellationToken cancellationToken =  default);
        DbContext GetDbContext();
    }
}
