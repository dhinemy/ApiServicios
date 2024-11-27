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
    [RoutePrefix("api/FormaEntrega")]
    public class FormaEntregaController : ApiController
    {
        [HttpGet]
        [Route("LlenarComboFormaEntrega")]
        public List<tblFormaEntrega > LlenarComboformaentrega()
        {
            clsFormaEntrega formaEntrega = new clsFormaEntrega();
            return formaEntrega.LlenarComboFormaEntrega();
        }
    }
}