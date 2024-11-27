using ApiTiendaAccesorios.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace ApiTiendaAccesorios.Clases
{
    public class clsDireccionCliente
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblDireccionCliente direccionCliente { get; set; }

        // Método para consultar una dirección por ID
        public tblDireccionCliente ConsultarXid(int id)
        {
            return bdTienda.tblDireccionClientes.FirstOrDefault(c => c.id == id);
        }

        // Método para insertar una nueva dirección
        public string Insertar()
        {
            try
            {
                bdTienda.tblDireccionClientes.Add(direccionCliente);
                bdTienda.SaveChanges();
                return $"Se insertó correctamente la dirección con ID {direccionCliente.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para actualizar una dirección existente
        public string Actualizar()
        {
            try
            {
                var _direccionCliente = ConsultarXid(direccionCliente.id);
                if (_direccionCliente == null)
                {
                    return $"No existe una dirección con el ID {direccionCliente.id}";
                }

                bdTienda.tblDireccionClientes.AddOrUpdate(direccionCliente);
                bdTienda.SaveChanges();
                return $"Se actualizó correctamente la dirección con ID {direccionCliente.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para eliminar una dirección existente
        public string Eliminar()
        {
            try
            {
                var _direccionCliente = ConsultarXid(direccionCliente.id);
                if (_direccionCliente == null)
                {
                    return $"No existe una dirección con el ID {direccionCliente.id}";
                }

                bdTienda.tblDireccionClientes.Remove(_direccionCliente);
                bdTienda.SaveChanges();
                return $"Se eliminó correctamente la dirección con ID {direccionCliente.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

       
    }
}
