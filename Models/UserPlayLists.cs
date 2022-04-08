namespace MusicPlaylist.Models;

public class UserPlayLists
{
    private static UserPlayLists instance = null;
    private IDictionary<String, Playlist> playlists;

    private UserPlayLists()
    {
        playlists = new Dictionary<String, Playlist>();
    }

    public static UserPlayLists Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UserPlayLists();
            }

            return instance;
        }
    }

    public String AddPlayList(Playlist pl)
    {
        String uuid = Guid.NewGuid().ToString();
        while (true)
        {
            if (playlists.TryAdd(uuid, pl))
            {
                break;
            }
        }

        return uuid;
    }

    public Playlist GetPlayListByUserToken(String userToken)
    {
        Playlist pl;
        if (! playlists.TryGetValue(userToken, out pl))
        {
            return null;
        }

        return pl;
    }
}