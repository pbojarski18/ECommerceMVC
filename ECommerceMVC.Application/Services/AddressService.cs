using AutoMapper;
using ECommerceMVC.Application.Dtos.Addresses;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Application.Services;

public class AddressService(IAddressRepository _addressRepository,
                            IMapper _mapper) : IAddressService
{
    public async Task<int> AddAsync(AddressDto addressDto, CancellationToken ct)
    {
        var addressEntity = _mapper.Map<AddressEntity>(addressDto);
        await _addressRepository.AddAsync(addressEntity, ct);
        return addressEntity.Id;
    }

    public async Task<IEnumerable<AddressEntity>> GetByUserIdAsync(string userId, CancellationToken ct)
    {
        if (userId == null)
        {
            throw new ArgumentNullException(nameof(userId));
        }
        return await _addressRepository.GetByUserIdAsync(userId, ct);
    }

    public async Task<AddressEntity> GetLastUsedByUserIdAsync(string userId, CancellationToken ct)
    {
        return await _addressRepository.GetLastUsedByUserIdAsync(userId, ct);
    }

    public async Task<int> GetOrCreateAsync(AddressDto addressDto, CancellationToken ct)
    {
        var addressEntity = _mapper.Map<AddressEntity>(addressDto);
        var addresses = await _addressRepository.GetByUserIdAsync(addressEntity.UserId, ct);
        var existingAddress = addresses.FirstOrDefault(p => p.BuildingNumber == addressEntity.BuildingNumber
                                                            && p.ApartmentNumber == addressEntity.ApartmentNumber
                                                            && p.Country == addressEntity.Country
                                                            && p.Street == addressEntity.Street
                                                            && p.PostalCode == addressEntity.PostalCode
                                                            && p.City == addressEntity.City);
        if (existingAddress != null)
        {
            return existingAddress.Id;
        }
        await _addressRepository.AddAsync(addressEntity, ct);
        return addressEntity.Id;
    }
}