using ApiTiendaAccesorios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ApiTiendaAccesorios.Clases
{
    public class clsProveedor
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblProveedor proveedor = new tblProveedor();

        public tblProveedor ConsultarXDocumento(string Documento)
        {
            return bdTienda.tblProveedors.FirstOrDefault(c => c.documento == Documento);
        }

        public string Insertar()
        {
            try
            {
                bdTienda.tblProveedors.Add(proveedor);
                bdTienda.SaveChanges();
                return $"Se insertó correctamente el cliente con documento {proveedor.documento}";
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
                tblProveedor _proveedor = ConsultarXDocumento(proveedor.documento);
                if (_proveedor == null)
                {
                    return $"No existe un cliente con el numero de documento {_proveedor.documento}";
                }
                bdTienda.tblProveedors.AddOrUpdate(proveedor);
                bdTienda.SaveChanges();
                return $"Se actualizó el cliente con documento {proveedor.documento}";
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
                tblProveedor _proveedor = ConsultarXDocumento(proveedor.documento);
                if (_proveedor == null)
                {
                    return $"No existe un cliente con documento {proveedor.documento}";
                }

                bdTienda.tblProveedors.Remove(proveedor);
                bdTienda.SaveChanges();
                return $"Se eliminó el cliente con documento {proveedor.documento}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<tblProveedor> LlenarComboProveedor()
        {
            return bdTienda.tblProveedors.ToList();
        }

        public IQueryable ListarConTipoDocumento()
        {
            return from tP in bdTienda.Set<tblProveedor>()
                   join tTD in bdTienda.Set<tblTipoDocumento>()
                   on tP.id_tipo_documento equals tTD.id
                   select new
                   {
                       Nombre = tP.razon_social,
                       TipoDocumento = tTD.Nombre,
                       Documento = tP.documento,
                       Activo = tP.activo
                   };
        }
    }
}