using System.Collections.Generic;
using API_Test.Models.Media;

namespace API_Test.Models.Player
{
    public class PlayerDTO
    {
        public int ID {get;set;}

        public string Name {get;set;}

        public IList<MediaDTO> MediaCollection {get;set;} = new List<MediaDTO>();
    }
}