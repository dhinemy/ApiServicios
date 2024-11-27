using ApiTiendaAccesorios.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ApiTiendaAccesorios.Clases
{
    public class clsTelefonoProveedor
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblTelefonoProveedor telefonoProveedor { get; set; }

        // Método para consultar un teléfono de proveedor por ID
        public tblTelefonoProveedor ConsultarXid(int id)
        {
            return bdTienda.tblTelefonoProveedors.FirstOrDefault(tp => tp.id == id);
        }

        // Método para insertar un nuevo teléfono de proveedor
        public string Insertar()
        {
            try
            {
                bdTienda.tblTelefonoProveedors.Add(telefonoProveedor);
                bdTienda.SaveChanges();
                return $"Se insertó correctamente el teléfono del proveedor con ID {telefonoProveedor.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para actualizar un teléfono de proveedor existente
        public string Actualizar()
        {
            try
            {
                var _telefonoProveedor = ConsultarXid(telefonoProveedor.id);
                if (_telefonoProveedor == null)
                {
                    return $"No existe un teléfono con el ID {telefonoProveedor.id}";
                }

                bdTienda.tblTelefonoProveedors.AddOrUpdate(telefonoProveedor);
                bdTienda.SaveChanges();
                return $"Se actualizó correctamente el teléfono del proveedor con ID {telefonoProveedor.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para eliminar un teléfono de proveedor existente
        public string Eliminar()
        {
            try
            {
                var _telefonoProveedor = ConsultarXid(telefonoProveedor.id);
                if (_telefonoProveedor == null)
                {
                    return $"No existe un teléfono con el ID {telefonoProveedor.id}";
                }

                bdTienda.tblTelefonoProveedors.Remove(_telefonoProveedor);
                bdTienda.SaveChanges();
                return $"Se eliminó correctamente el teléfono del proveedor con ID {telefonoProveedor.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
