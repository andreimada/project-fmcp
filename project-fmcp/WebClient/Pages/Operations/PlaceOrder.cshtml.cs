using Bussiness.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebClient.Pages.Operations
{
    public class PlaceOrderModel : PageModel {
        private readonly IServiceInventory _inventoryService;

        public PlaceOrderModel(IServiceInventory inventoryService) {
            _inventoryService = inventoryService;
        }

        [BindProperty]
        public OrderDTO Order { get; set; }

        public void OnGet() {
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            try
            {
                await _inventoryService.PlaceOrderAsync(Order.ProductId, Order.WarehouseId, Order.Quantity);
                return RedirectToPage("/Success");
            }
            catch
            {
                return RedirectToPage("/Error");
            }
        }
    }

    public class OrderDTO {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
    }

}
