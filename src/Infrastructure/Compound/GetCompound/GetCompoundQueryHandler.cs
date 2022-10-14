using DotNatrium.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DotNatrium.Infrastructure.Compound.GetCompound;

public class GetCompoundQueryHandler
{
    private ApplicationContext _context;

    public GetCompoundQueryHandler(ApplicationContext ctx)
    {
        _context = ctx;
    }

    public async Task<DotNatrium.Models.Compound?> GetCompound(GetCompoundQuery query, CancellationToken cancellationToken)
    {
        if (query.DataId < 1) throw new ArgumentException("Invalid ID.");
        return await _context.Compound.Include(c => c.Data)
            .FirstOrDefaultAsync(c => c.DataId == query.DataId);
    }
}