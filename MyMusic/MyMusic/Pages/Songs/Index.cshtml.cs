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
    public class IndexModel : PageModel
    {
        private readonly MyMusic.Data.MusicContext _context;

        public IndexModel(MyMusic.Data.MusicContext context)
        {
            _context = context;
        }

        public IList<Song> Songs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Songs = await _context.Songs
                .Include(a => a.Artist)
                .Include(a => a.Album)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
