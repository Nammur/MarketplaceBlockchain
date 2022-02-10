using System.Collections.Generic;
using Itens.Models;

namespace Itens.Repository
{
    public interface IItemRepository
    {
        void Criar(Item item);
        void Editar(ItemViewModel item);
        bool Excluir(int id);
        List<Item> ListarItens();
        List<Item> ListarItensPlayer(int idPlayer);
        Item RecuperarItem(int id);
        Habilidade RecuperarItemHabilidade(int id);
        bool TransferirItem(int idItem, int idDono, int idComprador);
    }
}
