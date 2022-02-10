using Transferencias.Models;
using Transferencias.Repository;
using TrabalhoFinalBlockChain.Shared;

namespace Transferencias.Infra
{
    public class TransferenciaRepository : Repositorio, ITransferenciaRepository
    {
        public TransferenciaRepository(DataTransactionContext dataTransactionContext) : base(dataTransactionContext)
        {
        }

        public void Criar(TransferenciaViewModel transferencia)
        {
            var sql = @"INSERT INTO dbo.Transferencia
                                    (IdVendedor, IdItem, Valor, DataPublicacaoVenda, Vendido)
                                     Values 
                                    (@idVendedor, @idItem, @valor, @dataPublicacaoVenda, @vendido)";
            var @params = new List<DataParameter>
                    {
                        DataParameter.Create("idVendedor", transferencia.Vendedor.Id),
                        DataParameter.Create("idItem", transferencia.Item.Id),
                        DataParameter.Create("valor", transferencia.Valor),
                        DataParameter.Create("dataPublicacaoVenda", transferencia.DataPublicacaoVenda),
                        DataParameter.Create("vendido", transferencia.Vendido),
                    };

            Execute(sql, @params);
        }

        public void Editar(TransferenciaViewModel transferencia)
        {
            var sql = @"UPDATE dbo.Transferencia
                            SET IdComprador = @idComprador, Vendido = @vendido, DataTransferencia = @data
                            WHERE Id = @id";
            var @params = new List<DataParameter>
                {
                    DataParameter.Create("id",transferencia.Id),
                    DataParameter.Create("idComprador", transferencia.Comprador.Id),
                    DataParameter.Create("vendido", transferencia.Vendido),
                    DataParameter.Create("data", transferencia.DataTransferencia),
                };

            Execute(sql, @params);
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void ConcluirTransferencia(Transferencia transferencia)
        {
            var sql = @"UPDATE dbo.Transferencia
                            SET Vendido = @vendido, IdComprador = @idComprador, DataTransferencia = @dataTransferencia
                            WHERE Id = @id";
            var @params = new List<DataParameter>
                {
                    DataParameter.Create("id",transferencia.Id),
                    DataParameter.Create("idComprador", transferencia.IdComprador),
                    DataParameter.Create("dataCompra", transferencia.DataTransferencia),
                    DataParameter.Create("vendido", transferencia.Vendido),
                };

            Execute(sql, @params);
        }

        public List<Transferencia> ListarTransferenciasMercado()
        {
            var sql = @"SELECT * FROM dbo.Transferencia t 
                        inner join dbo.Item i on i.Id = t.IdItem
                        where t.Vendido = 'false' and i.IdChain is not NULL";

            return Query<Transferencia>(sql).ToList();
        }

        public List<Transferencia> ListarTransferenciasItem(int idItem)
        {
            var sql = @"SELECT * FROM dbo.Transferencia where IdItem = @idItem";

            var @params = new List<DataParameter>
            {
                DataParameter.Create("idItem", idItem),
            };

            return Query<Transferencia>(sql, @params).ToList();
        }

        public List<Transferencia> ListarTransferenciasPlayer(int idPlayer)
        {
            var sql = @"SELECT * FROM dbo.Transferencia where IdVendedor = @idPlayer";

            var @params = new List<DataParameter>
            {
                DataParameter.Create("idPlayer", idPlayer),
            };

            return Query<Transferencia>(sql, @params).ToList();
        }

        public Transferencia RecuperarTransferencia(int id)
        {
            var sql = @"SELECT * FROM dbo.Transferencia where Id = @id";
            var @params = new List<DataParameter>
            {
                DataParameter.Create("id", id),
            };

            return Query<Transferencia>(sql, @params).ToList().FirstOrDefault();
        }

        public Transferencia RecuperarTransferenciaAtiva(int idItem)
        {
            var sql = @"SELECT * FROM dbo.Transferencia where IdItem = @idItem and Vendido = @vendido";
            var @params = new List<DataParameter>
            {
                DataParameter.Create("idItem", idItem),
                DataParameter.Create("vendido", false),
            };

            return Query<Transferencia>(sql, @params).ToList().FirstOrDefault();
        }
    }
}