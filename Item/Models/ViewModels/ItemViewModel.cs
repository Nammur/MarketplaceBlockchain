using Newtonsoft.Json;
using Players.Models;
using System;

namespace Itens.Models
{
    public class ItemViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idChain")]
        public string IdChain { get; set; }

        [JsonProperty("dono")]
        public Player Dono { get; set; }

        [JsonProperty("tipo")]
        public int Tipo { get; set; }

        [JsonProperty("raridade")]
        public int Raridade { get; set; }
        
        [JsonProperty("ataque")]
        public int Ataque { get; set; }

        [JsonProperty("defesa")]
        public int Defesa { get; set; }

        [JsonProperty("acerto")]
        public int Acerto { get; set; }

        [JsonProperty("vida")]
        public int Vida { get; set; }

        [JsonProperty("habilidade")]
        public Habilidade Habilidade { get; set; }

        public ItemViewModel()
        {
            Dono = new Player();
            Habilidade = new Habilidade();
            IdChain = "";
        }

        public ItemViewModel(int id, string idChain, Player dono, int tipo, int raridade, int ataque, int defesa, int acerto, int vida, Habilidade habilidade)
        {
            Id = id;
            IdChain = idChain;
            Dono = dono;
            Tipo = tipo;
            Raridade = raridade;
            Ataque = ataque;
            Defesa = defesa;
            Acerto = acerto;
            Vida = vida;
            Habilidade = habilidade;
        }
    }
}
