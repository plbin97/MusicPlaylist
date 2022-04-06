using System.Globalization;
using CsvHelper;

namespace MusicPlaylist.Models;

public class Playlist
{
    private List<Song> MusicPlayList;

    public Playlist(String csvString)
    
    {
        using (var reader = new StringReader(csvString))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<SongMap>();
            MusicPlayList = csv.GetRecords<Song>().ToList();
        }
    }

    public int GetNumberOfSongs()
    {
        return MusicPlayList.Count;
    }

    public List<Song> GetPlayList()
    {
        return MusicPlayList;
    }

    public void AddSong(Song song)
    {
        MusicPlayList.Add(song);
    }

    public void AddSong(List<Song> songs)
    {
        foreach (Song song in songs)
        {
            MusicPlayList.Add(song);
        }
    }

}