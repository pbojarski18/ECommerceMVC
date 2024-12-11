using ECommerceMVC.Domain.Repositories;
using ECommerceMVC.Persistence.Context;

namespace ECommerceMVC.Persistence.Repositories;

public class BaseRepository(ApplicationDbContext _applicationDbContext) : IBaseRepository
{
    private readonly ApplicationDbContext _applicationDbContext = _applicationDbContext;

    public async Task AddAsync<TEntity>(TEntity entity, CancellationToken ct) where TEntity : class
    {
        await _applicationDbContext.AddAsync(entity, ct);
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        _applicationDbContext.Remove(entity);
    }

    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        => _applicationDbContext.Set<TEntity>();

    public async Task<int> SaveAsync(CancellationToken ct = default)
        => await _applicationDbContext.SaveChangesAsync(ct);

    public void Update<TEntity>(TEntity entity) where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        _applicationDbContext.Update(entity);
    }

    public void AddRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : class
    {
        _applicationDbContext.AddRange(entity);
    }

    public void UpdateRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : class
    {
        _applicationDbContext.UpdateRange(entity);
    }
}