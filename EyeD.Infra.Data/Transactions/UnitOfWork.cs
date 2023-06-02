using EyeD.Infra.Data.Context;

namespace EyeD.Infra.Data.Transactions;

public sealed class UnitOfWork : IUnitOfWork
{
    private EyeDContext _context;

    public UnitOfWork(EyeDContext context)
    {
        _context = context;
    }
    public async Task<int> SaveChangesAsync()
    => await _context.SaveChangesAsync();
}
