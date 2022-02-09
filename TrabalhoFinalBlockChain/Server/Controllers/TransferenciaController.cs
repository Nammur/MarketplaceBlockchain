using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Transferencias.Models;
using Transferencias.Services;

namespace TrabalhoFinalBlockChain.Server.Controllers
{
    [Controller]
    [Route("api/transferencia")]
    public class TransferenciaController : Controller
    {
        readonly TransferenciaService _transferenciaService;

        public TransferenciaController(TransferenciaService transferenciaService)
        {
            _transferenciaService = transferenciaService;
        }

        [HttpGet("ListarTransferenciasMercado")]
        public ActionResult<List<TransferenciaViewModel>> ListarTransferenciasMercado()
        {
            return _transferenciaService.ListarTransferenciasMercado();
        }

        //[HttpGet("Recuperar")]
        //public ActionResult<ItemViewModel> Recuperar(int id)
        //{
        //    return _itemService.RecuperarItem(id);
        //}

        [HttpPut("Comprar")]
        public ActionResult Comprar([FromBody] TransferenciaViewModel transferencia)
        {
            _transferenciaService.Comprar(transferencia);
            return Ok();
        }

        [HttpPut("Vender")]
        public ActionResult VenderItem([FromBody] TransferenciaViewModel transferencia)
        {
            _transferenciaService.Criar(transferencia);
            return Ok();
        }

        //[HttpPut]
        //public ActionResult Editar([FromBody] ItemViewModel item)
        //{
        //    _itemService.Editar(item);
        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult Excluir(int id)
        //{
        //    var resultado = _itemService.Excluir(id);
        //    if (!resultado)
        //    {
        //        return Json(new { status = false, notificacoes = "Falha ao excluir o Item." });
        //    }

        //    return Json(new { status = true, notificacoes = "Item excluído." });
        //}

    }
}
