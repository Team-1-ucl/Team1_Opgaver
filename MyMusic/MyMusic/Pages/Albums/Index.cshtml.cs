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
    public class IndexModel : PageModel
    {
        private readonly MyMusic.Data.MusicContext _context;

        public IndexModel(MyMusic.Data.MusicContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Albums != null)
            {
                Album = await _context.Albums.ToListAsync();
            }
        }
    }
}
