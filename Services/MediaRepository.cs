using System.Collections.Generic;
using System.Linq;
using API_Test.Models.Media;

public class MediaRepository
{
    public static MediaRepository Instance = new MediaRepository();

    public MediaRepository()
    {
        MediaItems = new []
        {
            new MediaDTO
            {
                ID = 1,
                Description = "Image"
            },
            new MediaDTO
            {
                ID = 2,
                Description = "Video"
            }
        };
    }

    public IEnumerable<MediaDTO> MediaItems
    {
        get;
        set;
    }

    public MediaDTO GetMedia(int id)
    {
        return MediaItems.FirstOrDefault(p => p.ID == id);
    }
}