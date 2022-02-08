using Newtonsoft.Json;
using System;

namespace Players.Models
{
    public class Player
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idCarteira")]
        public string IdCarteira { get; set; }

        [JsonProperty("nick")]
        public string Nick { get; set; }

        public Player() 
        {
            Nick = "";
            IdCarteira = "";
        }

        public Player(int id, string idCarteira, string nick)
        {
            Id = id;
            IdCarteira = idCarteira;
            Nick = nick;
        }
    }

}
