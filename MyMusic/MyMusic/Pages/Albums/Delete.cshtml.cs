using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMusic.Data;
using MyMusic.Models;

namespace MyMusic.Pages.Albums
{
    public class DeleteModel : PageModel
    {
        private readonly MyMusic.Data.MusicContext _context;

        public DeleteModel(MyMusic.Data.MusicContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Album Album { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FirstOrDefaultAsync(m => m.Id == id);

            if (album == null)
            {
                return NotFound();
            }
            else 
            {
                Album = album;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }
            var album = await _context.Albums.FindAsync(id);

            if (album != null)
            {
                Album = album;
                _context.Albums.Remove(Album);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
