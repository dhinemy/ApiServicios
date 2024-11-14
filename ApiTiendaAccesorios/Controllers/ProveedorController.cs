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
    [EnableCors(origins: "http://localhost:61762", headers:"*", methods:"*")]
    [RoutePrefix("api/Proveedores")]
    public class ProveedorController : ApiController
    {
        [HttpGet]
        [Route("LlenarComboProveedor")]
        public List<tblProveedor> LlenarComboProveedor()
        {
            clsProveedor proveedor = new clsProveedor();
            return proveedor.LlenarComboProveedor();
        }

        [HttpGet]
        [Route("ConsultarXDocumento")]
        public tblProveedor ConsultarXDocumento(string Documento)
        {
            clsProveedor proveedor = new clsProveedor();
            return proveedor.ConsultarXDocumento(Documento);
        }

        [HttpGet]
        [Route("ListarConTipoDocumento")]
        public IQueryable ListarConTipoDocumento()
        {
            clsProveedor proveedor = new clsProveedor();
            return proveedor.ListarConTipoDocumento();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblProveedor _proveedor)
        {
            clsProveedor proveedor = new clsProveedor();
            proveedor.proveedor = _proveedor;
            return proveedor.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblProveedor proveedor)
        {
            clsProveedor _proveedor = new clsProveedor();
            _proveedor.proveedor = proveedor;
            return _proveedor.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] tblProveedor proveedor)
        {
            clsProveedor _proveedor = new clsProveedor();
            _proveedor.proveedor = proveedor;
            return _proveedor.Eliminar();
        }
    }
}