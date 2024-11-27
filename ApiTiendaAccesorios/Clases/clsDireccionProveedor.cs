using ApiTiendaAccesorios.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace ApiTiendaAccesorios.Clases
{
    public class clsDireccionProveedor
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblDireccionProveedor direccionProveedor { get; set; }

        // Método para consultar una dirección de proveedor por ID
        public tblDireccionProveedor ConsultarXid(int id)
        {
            return bdTienda.tblDireccionProveedors.FirstOrDefault(c => c.id == id);
        }

        // Método para insertar una nueva dirección de proveedor
        public string Insertar()
        {
            try
            {
                bdTienda.tblDireccionProveedors.Add(direccionProveedor);
                bdTienda.SaveChanges();
                return $"Se insertó correctamente la dirección del proveedor con ID {direccionProveedor.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para actualizar una dirección de proveedor existente
        public string Actualizar()
        {
            try
            {
                var _direccionProveedor = ConsultarXid(direccionProveedor.id);
                if (_direccionProveedor == null)
                {
                    return $"No existe una dirección de proveedor con el ID {direccionProveedor.id}";
                }

                bdTienda.tblDireccionProveedors.AddOrUpdate(direccionProveedor);
                bdTienda.SaveChanges();
                return $"Se actualizó correctamente la dirección del proveedor con ID {direccionProveedor.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para eliminar una dirección de proveedor existente
        public string Eliminar()
        {
            try
            {
                var _direccionProveedor = ConsultarXid(direccionProveedor.id);
                if (_direccionProveedor == null)
                {
                    return $"No existe una dirección de proveedor con el ID {direccionProveedor.id}";
                }

                bdTienda.tblDireccionProveedors.Remove(_direccionProveedor);
                bdTienda.SaveChanges();
                return $"Se eliminó correctamente la dirección del proveedor con ID {direccionProveedor.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
