using Bussiness.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebClient.Pages.Operations
{
    public class IndexModel : PageModel
    {
        private readonly IServiceWarehouse _warehouseService;

        public IndexModel(IServiceWarehouse warehouseService) {
            _warehouseService = warehouseService;
        }

        public IList<global::Shared.Models.Warehouse> Warehouses { get; set; }

        public async Task OnGetAsync() {
            Warehouses = await _warehouseService.GetAllAsync() as IList<global::Shared.Models.Warehouse>;
        }
    }
}
