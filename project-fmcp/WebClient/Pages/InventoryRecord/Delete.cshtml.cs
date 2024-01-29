using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Shared.Models;

namespace WebClient.Pages.InventoryRecord
{
    public class DeleteModel : PageModel
    {
        private readonly Data.Contexts.SqliteContext _context;

        public DeleteModel(Data.Contexts.SqliteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public global::Shared.Models.InventoryRecord InventoryRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.InventoryRecords == null)
            {
                return NotFound();
            }

            var inventoryrecord = await _context.InventoryRecords.FirstOrDefaultAsync(m => m.RecordId == id);

            if (inventoryrecord == null)
            {
                return NotFound();
            }
            else 
            {
                InventoryRecord = inventoryrecord;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.InventoryRecords == null)
            {
                return NotFound();
            }
            var inventoryrecord = await _context.InventoryRecords.FindAsync(id);

            if (inventoryrecord != null)
            {
                InventoryRecord = inventoryrecord;
                _context.InventoryRecords.Remove(InventoryRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
