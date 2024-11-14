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
    [RoutePrefix("api/Cliente")]
    public class ClientesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXDocumento")]
        public tblCliente ConsultarXDocumento(string Documento)
        {
            clsCliente cliente = new clsCliente();
            return cliente.ConsultarXDocumento(Documento);
        }

        [HttpGet]
        [Route("ListarConTipoDocumento")]
        public IQueryable ListarConTipoDocumento()
        {
            clsCliente cliente = new clsCliente();
            return cliente.ListarConTipoDocumento();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblCliente _cliente)
        {
            clsCliente cliente = new clsCliente();
            cliente.cliente = _cliente;
            return cliente.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblCliente cliente)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = cliente;
            return _cliente.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] tblCliente cliente)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = cliente;
            return _cliente.Eliminar();
        }
    }
}