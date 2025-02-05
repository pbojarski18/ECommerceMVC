using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Domain.Repositories;

public interface IAddressRepository
{
    Task<int> AddAsync(AddressEntity address, CancellationToken ct);

    Task<IEnumerable<AddressEntity>> GetByUserIdAsync(string userId, CancellationToken ct);

    Task<AddressEntity> GetLastUsedByUserIdAsync(string userId, CancellationToken ct);
}