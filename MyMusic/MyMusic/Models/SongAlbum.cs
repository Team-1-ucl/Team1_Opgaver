namespace MyMusic.Models
{
    public class SongAlbum
    {
        
        public int Id { get; set; }



        public Album Album { get; set; }
        public int AlbumId { get; set; }    

        public Song Song { get; set; }
        public int SongId { get; set; }

    }
}
