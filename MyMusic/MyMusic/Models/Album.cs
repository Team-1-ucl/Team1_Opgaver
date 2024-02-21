namespace MyMusic.Models;

public class Album
{
    public int Id { get; set; }   
    public string? Title { get; set; }

    public ICollection<Song>? Songs { get; set; }
    public ICollection<Artist>? Artists { get; set; }
    public GenreAlbum? GenreAlbum { get; set; }

}
