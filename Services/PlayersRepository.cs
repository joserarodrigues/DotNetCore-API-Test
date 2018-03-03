using System.Collections.Generic;
using System.Linq;

public class PlayersRepository
{
    public static PlayersRepository Instance = new PlayersRepository();

    public PlayersRepository()
    {
        Players = new []
        {
            new PlayerDTO
            {
                ID = 1,
                Name = "One"
            },
            new PlayerDTO
            {
                ID = 2,
                Name = "Two"
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