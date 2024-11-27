using ApiTiendaAccesorios.Clases;
using ApiTiendaAccesorios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiTiendaAccesorios.Controllers
{
    [EnableCors(origins: "http://localhost:61762", headers: "*", methods: "*")]
    [RoutePrefix("api/Pedido")]
    public class PedidoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXid")]
        public tblPedido ConsultarXid(int id)
        {
            clsPedido pedido = new clsPedido();
            return pedido.ConsultarXid(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblPedido _pedido)
        {
            clsPedido pedido = new clsPedido();
            pedido.pedido = _pedido;
            return pedido.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblPedido pedido)
        {
            clsPedido _pedido = new clsPedido();
            _pedido.pedido = pedido;
            return _pedido.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] tblPedido pedido)
        {
            clsPedido _pedido = new clsPedido();
            _pedido.pedido = pedido;
            return _pedido.Eliminar();
        }
    }
}
