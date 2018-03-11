using System.Collections.Generic;

public class PlayerDTO
{
    public int ID {get;set;}

    public string Name {get;set;}

    public IEnumerable<MediaDTO> MediaCollection {get;set;} = new List<MediaDTO>();
}