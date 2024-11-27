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
    [RoutePrefix("api/TelefonoProveedor")]
    public class TelefonoProveedorController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXid")]
        public tblTelefonoProveedor ConsultarXid(int id)
        {
            clsTelefonoProveedor telefonoProveedor = new clsTelefonoProveedor();
            return telefonoProveedor.ConsultarXid(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblTelefonoProveedor _telefonoProveedor)
        {
            clsTelefonoProveedor telefonoProveedor = new clsTelefonoProveedor();
            telefonoProveedor.telefonoProveedor = _telefonoProveedor;
            return telefonoProveedor.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblTelefonoProveedor telefonoProveedor)
        {
            clsTelefonoProveedor _telefonoProveedor = new clsTelefonoProveedor();
            _telefonoProveedor.telefonoProveedor = telefonoProveedor;
            return _telefonoProveedor.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] tblTelefonoProveedor telefonoProveedor)
        {
            clsTelefonoProveedor _telefonoProveedor = new clsTelefonoProveedor();
            _telefonoProveedor.telefonoProveedor = telefonoProveedor;
            return _telefonoProveedor.Eliminar();
        }
    }
}
