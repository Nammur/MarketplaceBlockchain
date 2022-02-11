using Microsoft.AspNetCore.Mvc;
using Itens.Services;
using Itens.Models;
using System.Collections.Generic;

namespace TrabalhoFinalBlockChain.Server.Controllers
{
    [Controller]
    [Route("api/Item")]
    public class ItemController : Controller
    {
        readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("Listar")]
        public ActionResult<List<ItemViewModel>> Listar()
        {
            return _itemService.ListarItens();
        }

        [HttpGet("ListarItensPlayer")]
        public ActionResult<List<ItemViewModel>> ListarItensPlayer(int idPlayer)
        {
            return _itemService.ListarItensPlayer(idPlayer);
        }

        [HttpGet("Recuperar")]
        public ActionResult<ItemViewModel> Recuperar(int id)
        {
            return _itemService.RecuperarItem(id);
        }

        [HttpPost("Criar")]
        public ActionResult Criar([FromBody]ItemViewModel item)
        {
            _itemService.Criar(item);
            return Ok();
        }
        [HttpPost("CriarHabilidade")]
        public ActionResult CriarHabilidade([FromBody] Habilidade habilidade)
        {
            _itemService.CriarHabilidade(habilidade);
            return Ok();
        }

        [HttpGet("ListarHabilidades")]
        public ActionResult<List<Habilidade>> ListarHabilidades()
        {
            return _itemService.ListarHabilidades();
        }

        [HttpPut]
        public ActionResult Editar([FromBody] ItemViewModel item)
        {
            _itemService.Editar(item);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            var resultado = _itemService.Excluir(id);
            if (!resultado)
            {
                return Json(new { status = false, notificacoes = "Falha ao excluir o Item." });
            }

            return Json(new { status = true, notificacoes = "Item excluído." });
        }
        
    }
}
