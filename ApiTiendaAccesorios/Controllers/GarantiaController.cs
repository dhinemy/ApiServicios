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
    [RoutePrefix("api/Garantia")]
    public class GarantiaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXid")]
        public tblGarantia ConsultarXid(int id)
        {
            clsGarantia garantia = new clsGarantia();
            return garantia.ConsultarXid(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblGarantia _garantia)
        {
            clsGarantia garantia = new clsGarantia();
            garantia.garantia = _garantia;
            return garantia.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblGarantia garantia)
        {
            clsGarantia _garantia = new clsGarantia();
            _garantia.garantia = garantia;
            return _garantia.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] tblGarantia garantia)
        {
            clsGarantia _garantia = new clsGarantia();
            _garantia.garantia = garantia;
            return _garantia.Eliminar();
        }
    }
}
