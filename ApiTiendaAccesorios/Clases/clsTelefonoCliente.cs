using ApiTiendaAccesorios.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ApiTiendaAccesorios.Clases
{
    public class clsTelefonoCliente
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblTelefonoCliente telefonoCliente { get; set; }

        // Método para consultar un teléfono de cliente por ID
        public tblTelefonoCliente ConsultarXid(int id)
        {
            return bdTienda.tblTelefonoClientes.FirstOrDefault(tc => tc.id == id);
        }

        // Método para insertar un nuevo teléfono de cliente
        public string Insertar()
        {
            try
            {
                bdTienda.tblTelefonoClientes.Add(telefonoCliente);
                bdTienda.SaveChanges();
                return $"Se insertó correctamente el teléfono del cliente con ID {telefonoCliente.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para actualizar un teléfono de cliente existente
        public string Actualizar()
        {
            try
            {
                var _telefonoCliente = ConsultarXid(telefonoCliente.id);
                if (_telefonoCliente == null)
                {
                    return $"No existe un teléfono con el ID {telefonoCliente.id}";
                }

                bdTienda.tblTelefonoClientes.AddOrUpdate(telefonoCliente);
                bdTienda.SaveChanges();
                return $"Se actualizó correctamente el teléfono del cliente con ID {telefonoCliente.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para eliminar un teléfono de cliente existente
        public string Eliminar()
        {
            try
            {
                var _telefonoCliente = ConsultarXid(telefonoCliente.id);
                if (_telefonoCliente == null)
                {
                    return $"No existe un teléfono con el ID {telefonoCliente.id}";
                }

                bdTienda.tblTelefonoClientes.Remove(_telefonoCliente);
                bdTienda.SaveChanges();
                return $"Se eliminó correctamente el teléfono del cliente con ID {telefonoCliente.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
