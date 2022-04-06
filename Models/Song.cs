using CsvHelper.Configuration;

namespace MusicPlaylist.Models;

public class Song
{
    public string Name { get; set; }
    public string Artist { get; set; }
}

public class SongMap : ClassMap<Song>
{
    public SongMap()
    {
        Map(m => m.Name);
        Map(m => m.Artist);
    }
}