using System.Collections.Generic;
using Players.Models;

namespace Players.Repository
{
    public interface IPlayerRepository
    {
        void Criar(Player player);
        void Editar(Player player);
        bool Excluir(int id);
        List<Player> ListarPlayers();
        Player RecuperarPlayer(int id);
        Player RecuperarPlayer(string idCarteira);
    }
}
