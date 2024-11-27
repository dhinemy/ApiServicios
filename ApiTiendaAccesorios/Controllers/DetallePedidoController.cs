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
    [RoutePrefix("api/DetallePedido")]
    public class DetallePedidoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXid")]
        public tblDetallePedido ConsultarXid(int id)
        {
            clsDetallePedido detallePedido = new clsDetallePedido();
            return detallePedido.ConsultaXid(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblDetallePedido _detallePedido)
        {
            clsDetallePedido detallePedido = new clsDetallePedido();
            detallePedido.detallePedido = _detallePedido;
            return detallePedido.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblDetallePedido detallePedido)
        {
            clsDetallePedido _detallePedido = new clsDetallePedido();
            _detallePedido.detallePedido = detallePedido;
            return _detallePedido.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] tblDetallePedido detallePedido)
        {
            clsDetallePedido _detallePedido = new clsDetallePedido();
            _detallePedido.detallePedido = detallePedido;
            return _detallePedido.Eliminar();
        }
    }
}
