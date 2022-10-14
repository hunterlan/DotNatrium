using DotNatrium.Helpers;

namespace DotNatrium.Infrastructure.Compound.AddCompound;

public class AddCompoundQueryHandler
{
    private ApplicationContext _context;

    public AddCompoundQueryHandler(ApplicationContext ctx)
    {
        _context = ctx;
    }

    public async Task AddCompound(AddCompoundQuery query, CancellationToken cancellationToken)
    {
        var addResult = _context.Data.Add(query.CompoundData);
        _context.Compound.Add(new Models.Compound()
        {
            DataId = addResult.Entity.Id
        });
        await _context.SaveChangesAsync(cancellationToken);
    }
}