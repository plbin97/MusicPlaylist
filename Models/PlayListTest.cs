using Xunit;

namespace MusicPlaylist.Models;

public class PlayListTest
{
    private Playlist playlist;

    public PlayListTest()
    {
        String testCsvStr =
            "Name,Artist,Composer\nDown,Marian Hill,Jeremy Lloyd & Samantha Gongol\nSugar (feat. Francesco Yates),Robin Schulz,\"Robin Schulz, Francesco Yates, Frankie J, Nathan Perez, Ronald Bryant, Dennis Bierbrodt, Guido Kramer & Jürgen Dohr\"";
        playlist = new Playlist(testCsvStr);
    }

    [Fact]
    public void GetNumberOfSongs()
    {
        Assert.Equal(2, playlist.GetNumberOfSongs());
    }

    [Fact]
    public void CheckSongs()
    {
        List<Song> pl = playlist.GetPlayList();
        Assert.Equal("Down", pl[0].Name);
        Assert.Equal("Sugar (feat. Francesco Yates)", pl[1].Name);
    }
    
}