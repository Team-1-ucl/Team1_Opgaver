using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMusic.Data;
using MyMusic.Models;

namespace MyMusic.Pages.Songs
{
    public class DetailsModel : PageModel
    {
        private readonly MyMusic.Data.MusicContext _context;

        public DetailsModel(MyMusic.Data.MusicContext context)
        {
            _context = context;
        }

      public Song Song { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            Song = await _context.Songs
                 .Include(s => s.Album)
                 .ThenInclude(e => e.Artists)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.Id == id);

            if (Song == null)
            {
                return NotFound();
            }
            else 
            {
                Song = Song;
            }
            return Page();
        }
    }
}
