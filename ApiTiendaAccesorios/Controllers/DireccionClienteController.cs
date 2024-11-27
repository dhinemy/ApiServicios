using ApiTiendaAccesorios.Clases;
using ApiTiendaAccesorios.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiTiendaAccesorios.Controllers
{
    [EnableCors(origins: "http://localhost:61762", headers: "*", methods: "*")]
    [RoutePrefix("api/DireccionCliente")]
    public class DireccionClienteController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXid")]
        public tblDireccionCliente ConsultarXid(int id)
        {
            clsDireccionCliente direccionCliente = new clsDireccionCliente();
            return direccionCliente.ConsultarXid(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblDireccionCliente _direccionCliente)
        {
            clsDireccionCliente direccionCliente = new clsDireccionCliente();
            direccionCliente.direccionCliente = _direccionCliente;
            return direccionCliente.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblDireccionCliente _direccionCliente)
        {
            clsDireccionCliente direccionCliente = new clsDireccionCliente();
            direccionCliente.direccionCliente = _direccionCliente;
            return direccionCliente.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] tblDireccionCliente _direccionCliente)
        {
            clsDireccionCliente direccionCliente = new clsDireccionCliente();
            direccionCliente.direccionCliente = _direccionCliente;
            return direccionCliente.Eliminar();
        }
    }
}
