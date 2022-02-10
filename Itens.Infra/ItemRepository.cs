using Itens.Models;
using Itens.Repository;
using TrabalhoFinalBlockChain.Shared;

namespace Itens.Infra
{
    public class ItemRepository : Repositorio, IItemRepository
    {
        public ItemRepository(DataTransactionContext dataTransactionContext) : base(dataTransactionContext)
        {
        }

        public void Criar(Item item)
        {
            throw new NotImplementedException();
        }

        public void Editar(ItemViewModel item)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<Item> ListarItens()
        {
            var sql = @"SELECT * FROM dbo.Item";

            return Query<Item>(sql).ToList();
        }

        public List<Item> ListarItensPlayer(int idPlayer)
        {
            var sql = @"SELECT * FROM dbo.Item where IdDono = @idDono";

            var @params = new List<DataParameter>
            {
                DataParameter.Create("idDono", idPlayer),
            };

            return Query<Item>(sql, @params).ToList();
        }

        public Item RecuperarItem(int id)
        {
            var sql = @"SELECT * FROM dbo.Item where Id = @id";
            var @params = new List<DataParameter>
            {
                DataParameter.Create("id", id),
            };

            return Query<Item>(sql, @params).ToList().FirstOrDefault();
        }

        public Habilidade RecuperarItemHabilidade(int id)
        {
            var sql = @"SELECT * FROM dbo.ItemHabilidade where Id = @id";
            var @params = new List<DataParameter>
            {
                DataParameter.Create("id", id),
            };

            return Query<Habilidade>(sql, @params).ToList().FirstOrDefault();
        }

        public bool TransferirItem(int idItem, int idDono, int idComprador)
        {
            try
            {
                var sql = @"UPDATE dbo.Item
                            SET IdDono = @idComprador
                            WHERE Id = @id and IdDono = @idDono";
                var @params = new List<DataParameter>
                {
                    DataParameter.Create("id",idItem),
                    DataParameter.Create("idComprador", idComprador),
                    DataParameter.Create("idDono", idDono),
                };

                Execute(sql, @params);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}