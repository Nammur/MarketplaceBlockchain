using Players.Models;
using Players.Repository;
using System;
using System.Collections.Generic;

namespace Players.Services
{
    public class PlayerService
    {
        readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository itemRepository)
        {
            _playerRepository = itemRepository;
        }

        public List<Player> ListarPlayers() => _playerRepository.ListarPlayers();

        public Player RecuperarPlayer(int id) => _playerRepository.RecuperarPlayer(id);
        
        public void Criar(Player player)
        {
            _playerRepository.Criar(player);
        }

        public void Editar(Player player)
        {
            _playerRepository.Editar(player);
        }

        public bool Excluir(int id) => _playerRepository.Excluir(id);
        
        public bool PlayerCadastrado (string idCarteira)
        {
            var player = _playerRepository.RecuperarPlayer(idCarteira);
            if(player != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
