using practicaMonse2xddxxd.Shared.Domain.Repostiroies;
using practicaMonse2xddxxd.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace practicaMonse2xddxxd.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}