using Newtonsoft.Json;
using System;

namespace Itens.Models
{
    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("idChain")]
        public string IdChain { get; private set; }

        [JsonProperty("idDono")]
        public int IdDono { get; private set; }

        [JsonProperty("tipo")]
        public int Tipo { get; private set; }

        [JsonProperty("raridade")]
        public int Raridade { get; private set; }
        
        [JsonProperty("ataque")]
        public int Ataque { get; private set; }

        [JsonProperty("defesa")]
        public int Defesa { get; private set; }

        [JsonProperty("acerto")]
        public int Acerto { get; private set; }

        [JsonProperty("vida")]
        public int Vida { get; private set; }

        [JsonProperty("idHabilidade")]
        public int IdHabilidade { get; private set; }

        public Item()
        {
            IdChain = "";
        }

        public Item(int id, string idChain, int idDono, int tipo, int raridade, int ataque, int defesa, int acerto, int vida, int idHabilidade)
        {
            Id = id;
            IdChain = idChain;
            IdDono = idDono;
            Tipo = tipo;
            Raridade = raridade;
            Ataque = ataque;
            Defesa = defesa;
            Acerto = acerto;
            Vida = vida;
            IdHabilidade = idHabilidade;
        }
    }

}
