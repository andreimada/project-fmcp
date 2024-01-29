using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Contexts;
using Shared.Models;

namespace WebClient.Pages.Warehouse
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
        public global::Shared.Models.Warehouse Warehouse { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Warehouses == null || Warehouse == null)
            {
                return Page();
            }

            _context.Warehouses.Add(Warehouse);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
