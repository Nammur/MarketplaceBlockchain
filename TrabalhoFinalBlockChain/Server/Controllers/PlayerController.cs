using Microsoft.AspNetCore.Mvc;
using Players.Models;
using Players.Services;
using System.Collections.Generic;

namespace TrabalhoFinalBlockChain.Server.Controllers
{
    [Controller]
    [Route("api/player")]
    public class PlayerController : Controller
    {
        readonly PlayerService _playerSercive;

        public PlayerController(PlayerService playerService)
        {
            _playerSercive = playerService;
        }

        [HttpGet("RecuperarPlayer")]
        public ActionResult<Player> RecuperarPlayer(string idCarteira)
        {
            return _playerSercive.RecuperarPlayer(idCarteira);
        }

        [HttpPost]
        public ActionResult Criar([FromBody]  Player player)
        {
            _playerSercive.Criar(player);
            return Ok();
        }
    }
}
