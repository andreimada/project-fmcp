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
    public class IndexModel : PageModel
    {
        private readonly Data.Contexts.SqliteContext _context;

        public IndexModel(Data.Contexts.SqliteContext context)
        {
            _context = context;
        }

        public IList<global::Shared.Models.InventoryRecord> InventoryRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.InventoryRecords != null)
            {
                InventoryRecord = await _context.InventoryRecords.ToListAsync();
            }
        }
    }
}
