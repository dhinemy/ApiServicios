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
    [RoutePrefix("api/TelefonoCliente")]
    public class TelefonoClienteController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXid")]
        public tblTelefonoCliente ConsultarXid(int id)
        {
            clsTelefonoCliente telefonoCliente = new clsTelefonoCliente();
            return telefonoCliente.ConsultarXid(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblTelefonoCliente _telefonoCliente)
        {
            clsTelefonoCliente telefonoCliente = new clsTelefonoCliente();
            telefonoCliente.telefonoCliente = _telefonoCliente;
            return telefonoCliente.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblTelefonoCliente telefonoCliente)
        {
            clsTelefonoCliente _telefonoCliente = new clsTelefonoCliente();
            _telefonoCliente.telefonoCliente = telefonoCliente;
            return _telefonoCliente.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] tblTelefonoCliente telefonoCliente)
        {
            clsTelefonoCliente _telefonoCliente = new clsTelefonoCliente();
            _telefonoCliente.telefonoCliente = telefonoCliente;
            return _telefonoCliente.Eliminar();
        }
    }
}
