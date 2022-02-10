using System.Collections.Generic;
using Transferencias.Models;

namespace Transferencias.Repository
{
    public interface ITransferenciaRepository
    {
        void Criar(TransferenciaViewModel transferencia);
        void Editar(TransferenciaViewModel transferencia);
        bool Excluir(int id);
        List<Transferencia> ListarTransferenciasPlayer(int idPLayer);
        List<Transferencia> ListarTransferenciasItem(int idItem);
        List<Transferencia> ListarTransferenciasMercado();
        void ConcluirTransferencia(Transferencia transferencia);
        Transferencia RecuperarTransferencia(int id);
        Transferencia RecuperarTransferenciaAtiva(int idItem);
    }
}
