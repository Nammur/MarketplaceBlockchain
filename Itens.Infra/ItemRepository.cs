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

        public void Criar(ItemViewModel item)
        {
            var sql = @"INSERT INTO dbo.Item
                                    (IdChain, Raridade, Tipo, Ataque, Defesa, Acerto, Vida, IdHabilidade)
                                     Values 
                                    (@idChain, @raridade, @tipo, @ataque, @defesa, @acerto, @vida, @habilidade)";
            var @params = new List<DataParameter>
                    {
                        DataParameter.Create("idChain", item.IdChain),
                        DataParameter.Create("ataque", item.Ataque),
                        DataParameter.Create("raridade", item.Raridade),
                        DataParameter.Create("tipo", item.Tipo),
                        DataParameter.Create("defesa", item.Defesa),
                        DataParameter.Create("acerto", item.Acerto),
                        DataParameter.Create("vida", item.Vida),
                        DataParameter.Create("habilidade", item.Habilidade.Id),

                    };

            Execute(sql, @params);
        }

        public void CriarHabilidade(Habilidade habilidade)
        {
            var sql = @"INSERT INTO dbo.ItemHabilidade
                                    (Efeito)
                                     Values 
                                    (@efeito)";
            var @params = new List<DataParameter>
                    {
                        DataParameter.Create("efeito", habilidade.Efeito)

                    };

            Execute(sql, @params);
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

        public List<Habilidade> ListarHabilidades()
        {
            var sql = @"SELECT * FROM dbo.ItemHabilidade";

            return Query<Habilidade>(sql).ToList();
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