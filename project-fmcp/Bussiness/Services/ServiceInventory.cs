using Data.Repositories;
using Shared.Models;

namespace Bussiness.Services;

public class ServiceInventory : IServiceInventory
{
    private readonly IRepositoryInventoryRecord _repositoryInventory;
    private readonly IRepositoryWarehouse _repositoryWarehouse;

    public ServiceInventory(IRepositoryInventoryRecord repositoryInventory, IRepositoryWarehouse repositoryWarehouse)
    {
        _repositoryInventory = repositoryInventory;
        _repositoryWarehouse = repositoryWarehouse;
    }

    public async Task<IEnumerable<InventoryRecord>> GetAllInventoryAsync()
    {
        return await _repositoryInventory.GetAllAsync();
    }

    public async Task<InventoryRecord> GetInventoryByIdAsync(int recordId)
    {
        return await _repositoryInventory.GetByIdAsync(recordId);
    }

    public async Task<int> AddInventoryRecordAsync(InventoryRecord record)
    {
        return await _repositoryInventory.AddAsync(record);
        
    }

    public async Task<int> UpdateInventoryRecordAsync(InventoryRecord record)
    {
        return await _repositoryInventory.UpdateAsync(record);
    }

    public async Task<int> DeleteInventoryRecordAsync(int recordId)
    {
        var record = await _repositoryInventory.GetByIdAsync(recordId);
        return await _repositoryInventory.DeleteAsync(record);
    }

    public async Task PlaceOrderAsync(int productId, int warehouseId, int quantity)
    {
        var record = await _repositoryInventory.GetRecordOfProductInWarehouse(productId, warehouseId);
        if (record != null && record.Quantity >= quantity)
        {
            record.Quantity -= quantity;
            await UpdateInventoryRecordAsync(record);
        }
        else if(record != null)
        {
            throw new Exception("Not enough items in selected warehouse!");
        }
        else
        {
            throw new Exception("ERROR");
        }
    }

    public async Task ReceiveShipmentAsync(int productId, int warehouseId, int quantity)
    {
        var record = await _repositoryInventory.GetRecordOfProductInWarehouse(productId, warehouseId);
        var warehouse = await _repositoryWarehouse.GetByIdAsync(warehouseId);
        
        if (record != null)
        {
            if (record.Quantity + quantity > warehouse.Capacity) {
                throw new Exception();
            }

            record.Quantity += quantity;
            await UpdateInventoryRecordAsync(record);
        }
        else
        {
            var elements = await GetAllInventoryAsync();
            record = new InventoryRecord(elements.Count()+1, productId, warehouseId, quantity);
            await AddInventoryRecordAsync(record);
        }
    }

    public async Task MoveBetweenWarehouses(int productId, int sourceWarehouseId, int destinationWarehouseId, int quantity)
    {
        var sourceRecord = await _repositoryInventory.GetRecordOfProductInWarehouse(productId, sourceWarehouseId);
        if (sourceRecord != null && sourceRecord.Quantity >= quantity) {
            sourceRecord.Quantity -= quantity;
            await UpdateInventoryRecordAsync(sourceRecord);

            var destinationRecord = await _repositoryInventory.GetRecordOfProductInWarehouse(productId, destinationWarehouseId);
            var destinationWarehouse = await _repositoryWarehouse.GetByIdAsync(destinationWarehouseId);
            if (destinationRecord != null)
            {
                if (destinationRecord.Quantity + quantity > destinationWarehouse.Capacity) {
                    throw new Exception();
                }
                destinationRecord.Quantity += quantity;
                await UpdateInventoryRecordAsync(destinationRecord);
            }
            else
            {
                var elements = await GetAllInventoryAsync();
                var record = new InventoryRecord(elements.Count() + 1, productId, destinationWarehouseId, quantity);
                await AddInventoryRecordAsync(record);
            }
        }
    }
}