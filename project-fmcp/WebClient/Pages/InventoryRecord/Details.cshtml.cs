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
    public class DetailsModel : PageModel
    {
        private readonly Data.Contexts.SqliteContext _context;

        public DetailsModel(Data.Contexts.SqliteContext context)
        {
            _context = context;
        }

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
    }
}
