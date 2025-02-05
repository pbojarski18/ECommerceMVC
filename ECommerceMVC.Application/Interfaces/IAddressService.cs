using ECommerceMVC.Application.Dtos.Addresses;
using ECommerceMVC.Domain.Entities;

namespace ECommerceMVC.Application.Interfaces;

public interface IAddressService
{
    Task<int> AddAsync(AddressDto addressDto, CancellationToken ct);

    Task<IEnumerable<AddressEntity>> GetByUserIdAsync(string userId, CancellationToken ct);

    Task<AddressEntity> GetLastUsedByUserIdAsync(string userId, CancellationToken ct);

    Task<int> GetOrCreateAsync(AddressDto addressDto, CancellationToken ct);
}