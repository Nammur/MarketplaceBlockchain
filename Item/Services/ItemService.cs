using Itens.Models;
using Itens.Repository;
using Players.Models;
using Players.Services;
using System;
using System.Collections.Generic;

namespace Itens.Services
{
    public class ItemService
    {
        readonly IItemRepository _itemRepository;
        readonly PlayerService _playerService;

        public ItemService(IItemRepository itemRepository, PlayerService playerService)
        {
            _itemRepository = itemRepository;
            _playerService = playerService;
        }

        public List<ItemViewModel> ListarItens()
        {
            var itens = _itemRepository.ListarItens();
            var itensViewModel = new List<ItemViewModel>();

            foreach (var item in itens)
            {
                itensViewModel.Add(ItemToViewModel(item));
            }

            return itensViewModel;
        }

        public List<ItemViewModel> ListarItensPlayer(int idPlayer)
        {
            var itens = _itemRepository.ListarItensPlayer(idPlayer);
            var itensViewModel = new List<ItemViewModel>();

            foreach (var item in itens)
            {
                itensViewModel.Add(ItemToViewModel(item));
            }

            return itensViewModel;
        }

        public List<Habilidade> ListarHabilidades()
        {
            return _itemRepository.ListarHabilidades();
        }

        public ItemViewModel RecuperarItem(int id)
        {
            var item = _itemRepository.RecuperarItem(id);
            return ItemToViewModel(item);
        }
        public Habilidade RecuperarHabilidade(int idHabilidade) => _itemRepository.RecuperarItemHabilidade(idHabilidade);

        public void Criar(ItemViewModel item)
        {
            _itemRepository.Criar(item);
        }
        public void CriarHabilidade(Habilidade habilidade)
        {
            _itemRepository.CriarHabilidade(habilidade);
        }
        public void Editar(ItemViewModel item)
        {
            _itemRepository.Editar(item);
        }
        public bool Excluir(int id) => _itemRepository.Excluir(id);

        private ItemViewModel ItemToViewModel(Item item)
        {
            var player = _playerService.RecuperarPlayer(item.IdDono);
            var habilidade = RecuperarHabilidade(item.IdHabilidade);
            
            return new ItemViewModel
            (
                item.Id, item.IdChain, player, item.Tipo, item.Raridade, 
                item.Ataque, item.Defesa, item.Acerto, item.Vida, habilidade
            );        
        }

        public bool TransferirItem(int idItem, int idDono, int idComprador) =>
            _itemRepository.TransferirItem(idItem, idDono, idComprador);

    }
}
