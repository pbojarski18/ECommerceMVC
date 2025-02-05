using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Persistence.Repositories;

public class AddressRepository(IBaseRepository _baseRepository) : IAddressRepository
{
    public async Task<int> AddAsync(AddressEntity address, CancellationToken ct)
    {
        await _baseRepository.AddAsync(address, ct);
        await _baseRepository.SaveAsync(ct);
        return address.Id;
    }

    public async Task<IEnumerable<AddressEntity>> GetByUserIdAsync(string userId, CancellationToken ct)
    {
        var addresses = await _baseRepository.GetAll<AddressEntity>()
            .Where(a => a.UserId == userId)
            .ToListAsync(ct);
        return addresses;
    }

    public async Task<AddressEntity> GetLastUsedByUserIdAsync(string userId, CancellationToken ct)
    {
        var address = await _baseRepository.GetAll<AddressEntity>()
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.CreateTimeUtc)
            .FirstOrDefaultAsync(ct);
        if (address == null)
        {
            return new AddressEntity();
        }
        return address;
    }
}