using ApiTiendaAccesorios.Clases;
using ApiTiendaAccesorios.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiTiendaAccesorios.Controllers
{
    [EnableCors(origins: "http://localhost:61762", headers: "*", methods: "*")]
    [RoutePrefix("api/DireccionProveedor")]
    public class DireccionProveedorController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXid")]
        public tblDireccionProveedor ConsultarXid(int id)
        {
            clsDireccionProveedor direccionProveedor = new clsDireccionProveedor();
            return direccionProveedor.ConsultarXid(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblDireccionProveedor _direccionProveedor)
        {
            clsDireccionProveedor direccionProveedor = new clsDireccionProveedor();
            direccionProveedor.direccionProveedor = _direccionProveedor;
            return direccionProveedor.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblDireccionProveedor _direccionProveedor)
        {
            clsDireccionProveedor direccionProveedor = new clsDireccionProveedor();
            direccionProveedor.direccionProveedor = _direccionProveedor;
            return direccionProveedor.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] tblDireccionProveedor _direccionProveedor)
        {
            clsDireccionProveedor direccionProveedor = new clsDireccionProveedor();
            direccionProveedor.direccionProveedor = _direccionProveedor;
            return direccionProveedor.Eliminar();
        }
    }
}
