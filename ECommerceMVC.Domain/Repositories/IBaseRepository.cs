namespace ECommerceMVC.Domain.Repositories;

public interface IBaseRepository
{
    Task AddAsync<TEntity>(TEntity entity, CancellationToken ct) where TEntity : class;

    void Delete<TEntity>(TEntity entity) where TEntity : class;

    IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

    Task<int> SaveAsync(CancellationToken ct = default);

    void Update<TEntity>(TEntity entity) where TEntity : class;

    void AddRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : class;

    void UpdateRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : class;
}
