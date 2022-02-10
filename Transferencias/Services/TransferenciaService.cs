using Itens.Services;
using Players.Models;
using Players.Services;
using Transferencias.Models;
using Transferencias.Repository;

namespace Transferencias.Services
{
    public class TransferenciaService
    {
        readonly ITransferenciaRepository _transferenciaRepository;
        readonly ItemService _itemService;
        readonly PlayerService _playerService;

        public TransferenciaService(ITransferenciaRepository transferenciaRepository,ItemService itemService, PlayerService playerService)
        {
            _transferenciaRepository = transferenciaRepository;
            _itemService = itemService;
            _playerService = playerService;
        }

        public List<TransferenciaViewModel> ListarTransferenciasItem(int idItem)
        {
            var transferencias = _transferenciaRepository.ListarTransferenciasItem(idItem);
            List<TransferenciaViewModel> transferenciasViewModels = new List<TransferenciaViewModel>();

            foreach(var trasn in transferencias)
            {
                transferenciasViewModels.Add(TransferenciaToViewModel(trasn));
            }   
            return transferenciasViewModels;
        }

        public List<TransferenciaViewModel> ListarTransferenciasPlayer(int idPLayer)
        {
            var transferencias = _transferenciaRepository.ListarTransferenciasPlayer(idPLayer);
            List<TransferenciaViewModel> transferenciasViewModels = new List<TransferenciaViewModel>();

            foreach (var trasn in transferencias)
            {
                transferenciasViewModels.Add(TransferenciaToViewModel(trasn));
            }
            return transferenciasViewModels;
        }

        public List<TransferenciaViewModel> ListarTransferenciasMercado()
        {
            var transferencias = _transferenciaRepository.ListarTransferenciasMercado();
            List<TransferenciaViewModel> transferenciasViewModels = new List<TransferenciaViewModel>();

            foreach (var trasn in transferencias)
            {
                transferenciasViewModels.Add(TransferenciaToViewModel(trasn));
            }
            return transferenciasViewModels;
        }
        public TransferenciaViewModel RecuperarTransferencia(int id)
        {
            var transferencia = _transferenciaRepository.RecuperarTransferencia(id);

            return TransferenciaToViewModel(transferencia);
        }

        public TransferenciaViewModel RecuperarTransferenciaAtiva(int idItem)
        {
            var transferencia = _transferenciaRepository.RecuperarTransferenciaAtiva(idItem);

            return TransferenciaToViewModel(transferencia);
        }

        private TransferenciaViewModel TransferenciaToViewModel(Transferencia transferencia)
        {
            if(transferencia == null)
                return new TransferenciaViewModel();
            var item = _itemService.RecuperarItem(transferencia.IdItem);
            var vendedor = _playerService.RecuperarPlayer(transferencia.IdVendedor);

            Player? comprador = null;

            if(transferencia.IdComprador != null)
                comprador = _playerService.RecuperarPlayer(transferencia.IdVendedor);

            return new TransferenciaViewModel(transferencia.Id, item, vendedor, comprador, transferencia.Valor,
                transferencia.DataPublicacaoVenda, transferencia.DataTransferencia, transferencia.Vendido);

        }
        
        public void Criar(TransferenciaViewModel transferencia)
        {
            transferencia.DataPublicacaoVenda = DateTime.Now;
            transferencia.Vendido = false;
            _transferenciaRepository.Criar(transferencia);
        }

        public void Editar(TransferenciaViewModel transferencia)
        {
            _transferenciaRepository.Editar(transferencia);
        }

        public bool Comprar(TransferenciaViewModel transferencia)
        {
            try
            {
                transferencia.DataTransferencia = DateTime.Now;
                transferencia.Vendido = true;
                Editar(transferencia);
                _itemService.TransferirItem(transferencia.Item.Id, transferencia.Vendedor.Id, transferencia.Comprador.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Excluir(int id) => _transferenciaRepository.Excluir(id);
        
    }
}
