using Players.Models;
using Players.Repository;
using TrabalhoFinalBlockChain.Shared;

namespace Players.Infra
{
    public class PlayerRepository : Repositorio, IPlayerRepository
    {
        public PlayerRepository(DataTransactionContext dataTransactionContext) : base(dataTransactionContext)
        {
        }

        public void Criar(Player player)
        {
            var sql = @"INSERT INTO dbo.Player
                                    (IdCarteira, Nick)
                                     Values 
                                    (@idCarteira, @nick)";
            var @params = new List<DataParameter>
                    {
                        DataParameter.Create("idCarteira", player.IdCarteira),
                        DataParameter.Create("nick", player.Nick),
                    };

            Execute(sql, @params);
        }

        public void Editar(Player player)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<Player> ListarPlayers()
        {
            throw new NotImplementedException();
        }

        public Player RecuperarPlayer(int id)
        {
            var sql = @"SELECT * FROM dbo.PLayer where Id = @id";
            var @params = new List<DataParameter>
            {
                DataParameter.Create("id", id),
            };

            return Query<Player>(sql, @params).ToList().FirstOrDefault();
        }

        public Player RecuperarPlayer(string idCarteira)
        {
            var sql = @"SELECT * FROM dbo.Player where IdCarteira = @idcarteira";
            var @params = new List<DataParameter>
            {
                DataParameter.Create("idCarteira", idCarteira),
            };

            return Query<Player>(sql, @params).ToList().FirstOrDefault();
        }
    }
}