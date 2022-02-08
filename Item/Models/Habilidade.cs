using Newtonsoft.Json;
using System;

namespace Itens.Models
{
    public class Habilidade
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("Efeito")]
        public string Efeito { get; set; }

        public Habilidade()
        {
            Efeito = "";
        }

        public Habilidade(int id, string efeito)
        {
            Id = id;
            Efeito = efeito;
        }
    }

}
