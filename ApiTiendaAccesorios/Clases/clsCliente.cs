using ApiTiendaAccesorios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ApiTiendaAccesorios.Clases
{
    public class clsCliente
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblCliente cliente {  get; set; }

        public tblCliente ConsultarXDocumento(string Documento)
        {
            return bdTienda.tblClientes.FirstOrDefault(c => c.nro_documento == Documento);
        }

        public string Insertar()
        {
            try
            {
                bdTienda.tblClientes.Add(cliente);
                bdTienda.SaveChanges();
                return $"Se insertó correctamente el cliente con documento {cliente.nro_documento}";
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
                tblCliente _cliente = ConsultarXDocumento(cliente.nro_documento);
                if(_cliente == null)
                {
                    return $"No existe un cliente con el numero de documento {_cliente.nro_documento}";
                }
                bdTienda.tblClientes.AddOrUpdate(cliente);
                bdTienda.SaveChanges();
                return $"Se actualizó el cliente con documento {cliente.nro_documento}";
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
                tblCliente _cliente = ConsultarXDocumento(cliente.nro_documento);
                if(_cliente == null)
                {
                    return $"No existe un cliente con documento {cliente.nro_documento}";
                }

                bdTienda.tblClientes.Remove(cliente);
                bdTienda.SaveChanges();
                return $"Se eliminó el cliente con documento {cliente.nro_documento}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable ListarConTipoDocumento()
        {
            return from tP in bdTienda.Set<tblTipoDocumento>()
                   join tC in bdTienda.Set<tblCliente>() on tP.id equals tC.id_tipo_documento
                   select new
                   {
                       idCliente = tP.id,
                       nombre = tC.nombre,
                       tipoDocumento = tP.Nombre,
                       Activo = tC.activo
                   };
        }

    }
}