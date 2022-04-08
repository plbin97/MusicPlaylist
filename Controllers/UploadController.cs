using Microsoft.AspNetCore.Mvc;
using MusicPlaylist.Models;

namespace MusicPlaylist.Controllers;

public class UploadController : Controller
{
    public async Task<String> GetBody()
    {
        String body = "";
        using (StreamReader stream = new StreamReader(Request.Body))
        {
            body = await stream.ReadToEndAsync();
        }
        return body;
    }
    
    [HttpPost]
    [Route("api/upload")]
    public async Task<IActionResult> UploadCsvData()
    {
        String csvString = await GetBody();
        if (csvString == "")
        {
            return Content("Empty");
        }
        Playlist playList;
        try
        {
            playList = new Playlist(csvString);
        }
        catch (Exception e)
        {
            return Content("Failed");
        }
        UserPlayLists userPlayList = UserPlayLists.Instance;
        String userID = userPlayList.AddPlayList(playList);
        return Content(userID);
    }
}