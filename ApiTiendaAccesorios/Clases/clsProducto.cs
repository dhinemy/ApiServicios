using ApiTiendaAccesorios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace ApiTiendaAccesorios.Clases
{
    public class clsProducto
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblProducto producto { get; set; }

        public tblProducto ConsultarXCodigo(string Codigo)
        {
            return bdTienda.tblProductoes.FirstOrDefault(c => c.codigo == Codigo);
        }

        public string Insertar()
        {
            try
            {
                bdTienda.tblProductoes.Add(producto);
                bdTienda.SaveChanges();
                return $"Se insertó correctamente el cliente con documento {producto.codigo}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                tblProducto _producto = ConsultarXCodigo(producto.codigo);
                if (_producto == null)
                {
                    return $"No existe un cliente con el numero de documento {producto.codigo}";
                }
                
                bdTienda.tblProductoes.AddOrUpdate(producto);
                bdTienda.SaveChanges();
                return $"Se actualizó el cliente con documento {producto.codigo}";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Eliminar()
        {
            try
            {
                tblProducto _producto = ConsultarXCodigo(producto.codigo);
                if (_producto == null)
                {
                    return $"No existe un cliente con documento {producto.codigo}";
                }

                bdTienda.tblProductoes.Remove(_producto);
                bdTienda.SaveChanges();
                return $"Se eliminó el cliente con documento {_producto.codigo}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable ListarConProveedor()
        {
            return from tP in bdTienda.Set<tblProducto>()
                   join tPT in bdTienda.Set<tblTipoProducto>() on tP.id_tipo_producto equals tPT.id
                   join TPr in bdTienda.Set<tblProveedor>() on tP.id_proveedor equals TPr.id
                   select new
                   {
                       Nombre = tP.nombre,
                       Codigo = tP.codigo,
                       ValorUnitario = tP.valor_unitario,
                       NombreProveedor = tPT.Nombre,
                       TipoProducto = TPr.razon_social,
                       TiempoGarantia = tP.tiempo_garantia,
                       Descuento = tP.descuento
                   };
        }
    }
}