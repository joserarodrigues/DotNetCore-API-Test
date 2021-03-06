using System.Collections.Generic;
using System.Linq;
using API_Test.Models.Media;
using API_Test.Models.Player;

public class PlayerRepository
{
    public static PlayerRepository Instance = new PlayerRepository();

    public PlayerRepository()
    {
        Players = new []
        {
            new PlayerDTO
            {
                ID = 1,
                Name = "One",
                MediaCollection = new List<MediaDTO> {
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
                }
            },
            new PlayerDTO
            {
                ID = 2,
                Name = "Two",
                MediaCollection = new List<MediaDTO> {
                    new MediaDTO
                    {
                        ID = 1,
                        Description = "Image"
                    }
                }
            },
            new PlayerDTO
            {
                ID = 3,
                Name = "Three"
            }
        };
    }

    public IEnumerable<PlayerDTO> Players
    {
        get;
        set;
    }

    public PlayerDTO GetPlayer(int id)
    {
        return Players.FirstOrDefault(p => p.ID == id);
    }
}