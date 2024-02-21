    namespace MyMusic.Models;

public class Genre
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public GenreAlbum? GenreAlbum { get; set; }
}