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
    [RoutePrefix("api/Producto")]
    public class ProductoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXCodigo")]
        public tblProducto ConsultarXCodigo(string Codigo)
        {
            clsProducto producto = new clsProducto();
            return producto.ConsultarXCodigo(Codigo);
        }

        [HttpGet]
        [Route("ListarConTipoDocumento")]
        public IQueryable ListarConTipoDocumento()
        {
            clsProducto producto = new clsProducto();
            return producto.ListarConProveedor();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblProducto _producto)
        {
            clsProducto producto = new clsProducto();
            producto.producto = _producto;
            return producto.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblProducto producto)
        {
            clsProducto _producto = new clsProducto();
            _producto.producto = producto;
            return _producto.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] tblProducto producto)
        {
            clsProducto _producto = new clsProducto();
            _producto.producto = producto;
            return _producto.Eliminar();
        }
    }
}