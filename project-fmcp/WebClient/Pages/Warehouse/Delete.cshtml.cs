using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Shared.Models;

namespace WebClient.Pages.Warehouse
{
    public class DeleteModel : PageModel
    {
        private readonly Data.Contexts.SqliteContext _context;

        public DeleteModel(Data.Contexts.SqliteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public global::Shared.Models.Warehouse Warehouse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Warehouses == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses.FirstOrDefaultAsync(m => m.WarehouseId == id);

            if (warehouse == null)
            {
                return NotFound();
            }
            else 
            {
                Warehouse = warehouse;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Warehouses == null)
            {
                return NotFound();
            }
            var warehouse = await _context.Warehouses.FindAsync(id);

            if (warehouse != null)
            {
                Warehouse = warehouse;
                _context.Warehouses.Remove(Warehouse);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
