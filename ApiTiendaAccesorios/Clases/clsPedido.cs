using ApiTiendaAccesorios.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ApiTiendaAccesorios.Clases
{
    public class clsPedido
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblPedido pedido { get; set; }

        // Método para consultar un pedido por ID
        public tblPedido ConsultarXid(int id)
        {
            return bdTienda.tblPedidoes.FirstOrDefault(p => p.id == id);
        }

        // Método para insertar un nuevo pedido
        public string Insertar()
        {
            try
            {
                bdTienda.tblPedidoes.Add(pedido);
                bdTienda.SaveChanges();
                return $"Se insertó correctamente el pedido con ID {pedido.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para actualizar un pedido existente
        public string Actualizar()
        {
            try
            {
                var _pedido = ConsultarXid(pedido.id);
                if (_pedido == null)
                {
                    return $"No existe un pedido con el ID {pedido.id}";
                }

                bdTienda.tblPedidoes.AddOrUpdate(pedido);
                bdTienda.SaveChanges();
                return $"Se actualizó correctamente el pedido con ID {pedido.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para eliminar un pedido existente
        public string Eliminar()
        {
            try
            {
                var _pedido = ConsultarXid(pedido.id);
                if (_pedido == null)
                {
                    return $"No existe un pedido con el ID {pedido.id}";
                }

                bdTienda.tblPedidoes.Remove(_pedido);
                bdTienda.SaveChanges();
                return $"Se eliminó correctamente el pedido con ID {pedido.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
