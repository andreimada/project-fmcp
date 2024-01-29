using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Contexts;
using Shared.Models;

namespace WebClient.Pages.InventoryRecord
{
    public class CreateModel : PageModel
    {
        private readonly Data.Contexts.SqliteContext _context;

        public CreateModel(Data.Contexts.SqliteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public global::Shared.Models.InventoryRecord InventoryRecord { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.InventoryRecords == null || InventoryRecord == null)
            {
                return Page();
            }

            _context.InventoryRecords.Add(InventoryRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
