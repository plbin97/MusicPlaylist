using Xunit;

namespace MusicPlaylist.Models;

[Collection("Sequential")]
public class UserPlayListsTest
{
    private String testUserID;
    public UserPlayListsTest()
    {
        UserPlayLists upl = UserPlayLists.Instance;
        String testCsvStr =
            "Name,Artist,Composer\nDown,Marian Hill,Jeremy Lloyd & Samantha Gongol\nSugar (feat. Francesco Yates),Robin Schulz,\"Robin Schulz, Francesco Yates, Frankie J, Nathan Perez, Ronald Bryant, Dennis Bierbrodt, Guido Kramer & Jürgen Dohr\"";
        Playlist pl = new Playlist(testCsvStr);
        testUserID = upl.AddPlayList(pl);
    }

    [Fact]
    public void CheckUserID()
    {
        Assert.NotNull(testUserID);
    }

    [Fact]
    public void GetPlayList()
    {
        UserPlayLists upl = UserPlayLists.Instance;
        Playlist pl = upl.GetPlayListByUserID(testUserID);
        Assert.NotNull(pl);
        Playlist nullPl = upl.GetPlayListByUserID(testUserID + '1');
        Assert.Null(nullPl);
    }
}