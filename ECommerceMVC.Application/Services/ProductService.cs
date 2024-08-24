﻿using AutoMapper;
using ECommerceMVC.Application.Abstraction;
using ECommerceMVC.Application.Dtos.Categories;
using ECommerceMVC.Application.Dtos.Products;
using ECommerceMVC.Application.Interfaces;
using ECommerceMVC.Domain.Entities;
using ECommerceMVC.Domain.Enums;
using ECommerceMVC.Domain.Repositories;

namespace ECommerceMVC.Application.Services;

public class ProductService(IProductRepository _productRepository,
                            IMapper _mapper,
                            IProductCategoryRepository _productCategoryRepository,
                            IStockRepository _stockRepository,
                            IStockHistoryRepository _stockHistoryRepository,
                            IUnitOfWork _unitOfWork) : IProductService
{
    private readonly IProductRepository _productRepository = _productRepository;
    private readonly IMapper _mapper = _mapper;
    private readonly IProductCategoryRepository _productCategoryRepository = _productCategoryRepository;
    private readonly IStockRepository _stockRepository = _stockRepository;
    private readonly IStockHistoryRepository stockHistoryRepository = _stockHistoryRepository;
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;


    public async Task<IEnumerable<ProductDto>> GetAllByFiltersAsync(CancellationToken ct)
    {
        var productEntities = await _productRepository.GetAllByFiltersAsync(ct);
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(productEntities);

        return productDtos;

    }

    public async Task<IEnumerable<ProductDto>> GetPagedByUserFiltersAsync(GetPagedByFiltersTransferDto filters, CancellationToken ct)
    {
        var productEntities = await _productRepository.GetPagedByUserFiltersAsync(filters, ct);
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(productEntities);

        return productDtos;
    }

    public async Task<int> AddAsync(AddProductDto addProductDto, CancellationToken ct)
    {
        using var transaction = await _unitOfWork.BeginTransactionAsync();
        try
        {
            var productEntity = _mapper.Map<ProductEntity>(addProductDto);

            await _productRepository.AddAsync(productEntity, ct);
            var stockEntity = new StockEntity { ProductQuantity = 0, CreateTimeUtc = DateTime.UtcNow, ProductId = productEntity.Id };
            await _stockRepository.AddAsync(stockEntity, ct);
            var stockHistory = new StockHistoryEntity { ProductQuantity = 0, CreateTimeUtc = DateTime.UtcNow, ProductId = productEntity.Id, StockId = stockEntity.Id, Message = $"Stock's been created for item {productEntity.Name}" };
            await _stockHistoryRepository.AddAsync(stockHistory, ct);
            return productEntity.Id;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> RemoveAsync(int productId, CancellationToken ct)
    {
        return await _productRepository.RemoveAsync(productId, ct);
    }

    public async Task<bool> EditAsync(EditProductDto editProductDto, CancellationToken ct)
    {

        var editedProduct = _mapper.Map<ProductEntity>(editProductDto);

        return await _productRepository.EditAsync(editedProduct, ct);
    }

    public async Task<ProductDto> GetByIdAsync(int productId, CancellationToken ct)
    {
        var product = await _productRepository.GetByIdAsync(productId, ct);
        var productDto = _mapper.Map<ProductDto>(product);

        return productDto;

    }

    public async Task<IEnumerable<ProductCategoryDto>> GetAllAsync(CancellationToken ct)
    {
        var productCategoryEntities = await _productCategoryRepository.GetAllAsync(ct);
        var productCategoriesDto = _mapper.Map<IEnumerable<ProductCategoryDto>>(productCategoryEntities);

        return productCategoriesDto;
    }



}
