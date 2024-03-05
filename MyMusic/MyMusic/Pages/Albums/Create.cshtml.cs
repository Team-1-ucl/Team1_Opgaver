using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMusic.Data;
using MyMusic.Models;

namespace MyMusic.Pages.Albums
{
    public class CreateModel : PageModel
    {
        private readonly MyMusic.Data.MusicContext _context;

        public CreateModel(MyMusic.Data.MusicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateSongOptions(); // Populate the list of available songs
            return Page();
        }

        [BindProperty]
        public Album Album { get; set; } = new Album();

        [BindProperty]
        public List<int> SelectedSongs { get; set; } // Property for selected songs

        public List<SelectListItem> SongOptions { get; set; } // Property for the list of available songs

        // Method to populate the list of available songs
        private void PopulateSongOptions()
        {
            SongOptions = _context.Songs
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.SongName
                })
                .ToList();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Album == null)
            {
                PopulateSongOptions(); // Repopulate the list of available songs
                return Page();
            }

            // Add the album to the context
            _context.Albums.Add(Album);
            await _context.SaveChangesAsync();

            // Associate selected songs with the album (assuming SongId is the foreign key)
            foreach (var songId in SelectedSongs)
            {
                var song = await _context.Songs.FindAsync(songId);
                if(song!=null)
                {
                    song.AlbumId = Album.Id;
                }
                
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
