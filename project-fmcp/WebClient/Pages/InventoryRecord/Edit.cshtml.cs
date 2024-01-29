using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Shared.Models;

namespace WebClient.Pages.InventoryRecord
{
    public class EditModel : PageModel
    {
        private readonly Data.Contexts.SqliteContext _context;

        public EditModel(Data.Contexts.SqliteContext context)
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

            var inventoryrecord =  await _context.InventoryRecords.FirstOrDefaultAsync(m => m.RecordId == id);
            if (inventoryrecord == null)
            {
                return NotFound();
            }
            InventoryRecord = inventoryrecord;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InventoryRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryRecordExists(InventoryRecord.RecordId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InventoryRecordExists(int id)
        {
          return (_context.InventoryRecords?.Any(e => e.RecordId == id)).GetValueOrDefault();
        }
    }
}
