using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMusic.Models;

namespace MyMusic.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext (DbContextOptions<MusicContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; } = default!;
        public DbSet<Song> Songs { get; set; } = default!;
        public DbSet<Artist> Artists { get; set; } = default!;
        public DbSet<Genre> Genres { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Song>().ToTable("Song");
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<Genre>().ToTable("Genre");
        }
    }
}
