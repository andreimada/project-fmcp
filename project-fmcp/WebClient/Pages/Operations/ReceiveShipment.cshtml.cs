using Bussiness.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebClient.Pages.Operations
{
    public class ReceiveShipmentModel : PageModel {
        private readonly IServiceInventory _inventoryService;

        public ReceiveShipmentModel(IServiceInventory inventoryService) {
            _inventoryService = inventoryService;
        }

        [BindProperty]
        public ShipmentDTO Shipment { get; set; }

        public void OnGet() {
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            try
            {
                await _inventoryService.ReceiveShipmentAsync(Shipment.ProductId, Shipment.WarehouseId, Shipment.Quantity);
                return RedirectToPage("/Success");
            }
            catch
            {
                return RedirectToPage("/Error");
            }
        }
    }

    public class ShipmentDTO {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
    }
}
