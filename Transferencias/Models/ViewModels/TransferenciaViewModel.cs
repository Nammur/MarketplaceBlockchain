using Itens.Models;
using Newtonsoft.Json;
using Players.Models;
using System;

namespace Transferencias.Models
{
    public class TransferenciaViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idItem")]
        public ItemViewModel Item { get; set; }

        [JsonProperty("idVendedor")]
        public Player Vendedor { get; set; }

        [JsonProperty("idComprador")]
        public Player? Comprador { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("dataPublicacaoVenda")]
        public DateTime DataPublicacaoVenda { get; set; }

        [JsonProperty("dataTransferencia")]
        public DateTime? DataTransferencia { get; set; }

        [JsonProperty("vendido")]
        public bool Vendido { get; set; }

        public TransferenciaViewModel()
        {
        }

        public TransferenciaViewModel(int id, ItemViewModel item, Player vendedor, Player? comprador, decimal valor, DateTime dataPublicacaoVenda, DateTime? dataTransferencia, bool vendido)
        {
            Id = id;
            Item = item;
            Vendedor = vendedor;
            Comprador = comprador;
            Valor = valor;
            DataPublicacaoVenda = dataPublicacaoVenda;
            DataTransferencia = dataTransferencia;
            Vendido = vendido;
        }
    }

}
