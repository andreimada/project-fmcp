using Shared.Models;

namespace Bussiness.Services {
    public interface IServiceInventory {
        Task<IEnumerable<InventoryRecord>> GetAllInventoryAsync();
        Task<InventoryRecord> GetInventoryByIdAsync(int recordId);
        Task<int> AddInventoryRecordAsync(InventoryRecord record);
        Task<int> UpdateInventoryRecordAsync(InventoryRecord record);
        Task<int> DeleteInventoryRecordAsync(int recordId);
        Task PlaceOrderAsync(int productId, int warehouseId, int quantity);
        Task ReceiveShipmentAsync(int productId, int warehouseId, int quantity);
        Task MoveBetweenWarehouses(int productId, int sourceWarehouseId, int destinationWarehouseId, int quantity);
    }
}
