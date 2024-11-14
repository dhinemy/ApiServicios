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
    [RoutePrefix("api/TipoDocumento")]
    public class TipoDocumentoController : ApiController
    {
        [HttpGet]
        [Route("LlenarComboTipoDocumento")]
        public List<tblTipoDocumento> LlenarComboTipoDocumento()
        {
            clsTipoDocumento tipoDocumento = new clsTipoDocumento();
            return tipoDocumento.LlenarComboTipoDocumento();
        }
    }
}