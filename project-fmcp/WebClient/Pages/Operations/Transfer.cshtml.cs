using Bussiness.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebClient.Pages.Operations
{
    public class TransferModel : PageModel {
        private readonly IServiceInventory _inventoryService;

        public TransferModel(IServiceInventory inventoryService) {
            _inventoryService = inventoryService;
        }

        [BindProperty]
        public TransferDTO Transfer { get; set; }

        public void OnGet() {
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            try
            {
                await _inventoryService.MoveBetweenWarehouses(
                    Transfer.ProductId,
                    Transfer.SourceWarehouseId,
                    Transfer.DestinationWarehouseId,
                    Transfer.Quantity);

                return RedirectToPage("/Success");
            }
            catch
            {
                return RedirectToPage("/Error");
            }
        }
    }

    public class TransferDTO {
        public int ProductId { get; set; }
        public int SourceWarehouseId { get; set; }
        public int DestinationWarehouseId { get; set; }
        public int Quantity { get; set; }
    }
}
