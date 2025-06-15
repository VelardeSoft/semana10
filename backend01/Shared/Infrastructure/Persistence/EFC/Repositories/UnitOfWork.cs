using backend01.Shared.Domain.Repositories;
using backend01.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace backend01.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    // inheritedDoc
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}