using Newtonsoft.Json;
using System;

namespace Transferencias.Models
{
    public class Transferencia
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idItem")]
        public int IdItem { get; set; }

        [JsonProperty("idVendedor")]
        public int IdVendedor { get; set; }

        [JsonProperty("idComprador")]
        public int? IdComprador { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("dataPublicacaoVenda")]
        public DateTime DataPublicacaoVenda { get; set; }

        [JsonProperty("dataTransferencia")]
        public DateTime? DataTransferencia { get; set; }

        [JsonProperty("vendido")]
        public bool Vendido { get; set; }

        public Transferencia()
        {
        }

        public Transferencia(int id, int idItem, int idVendedor, int idComprador, decimal valor, DateTime dataPublicacaoVenda, DateTime dataTransferencia, bool vendido)
        {
            Id = id;
            IdItem = idItem;
            IdVendedor = idVendedor;
            IdComprador = idComprador;
            Valor = valor;
            DataPublicacaoVenda = dataPublicacaoVenda;
            DataTransferencia = dataTransferencia;
            Vendido = vendido;
        }
    }    
}
