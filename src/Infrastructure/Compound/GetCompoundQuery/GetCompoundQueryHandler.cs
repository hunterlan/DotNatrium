using DotNatrium.Helpers;

namespace Infrastructure.Compound.GetCompoundQuery;

public class GetCompoundQueryHandler
{
    private ApplicationContext _context;

    public GetCompoundQueryHandler(ApplicationContext ctx)
    {
        _context = ctx;
    }

    public DotNatrium.Models.Compound? GetCompound(GetCompoundQueryRequest query, CancellationToken cancellationToken)
    {
        if (query.Id < 1) throw new ArgumentException("Invalid ID.");
        return _context.Compound.FirstOrDefault(c => c.Id == query.Id);
    }
}