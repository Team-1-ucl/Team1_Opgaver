namespace MyMusic.Models;

public class GenreAlbum
{
    public int Id { get; set; }


    public Genre? Genre { get; set; }
    public int GenreId{ get; set; }

    public Album? Album { get; set;}
    public int AlbumId { get; set; }
}