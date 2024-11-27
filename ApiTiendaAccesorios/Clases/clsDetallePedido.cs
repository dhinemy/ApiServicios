using ApiTiendaAccesorios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace ApiTiendaAccesorios.Clases
{
    public class clsDetallePedido
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();
        public tblDetallePedido detallePedido { get; set; }

        public tblDetallePedido ConsultaXid(int id)
        {
            return bdTienda.tblDetallePedidoes.FirstOrDefault(c => c.id == id);
        }

        public string Insertar()
        {
            try
            {
                bdTienda.tblDetallePedidoes.Add(detallePedido);
                bdTienda.SaveChanges();
                return $"Se insertó correctamente el detalle de pedido del pedido con id {detallePedido.id}";
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
                tblDetallePedido _detallePedido = ConsultaXid(detallePedido.id);
                if(_detallePedido == null)
                {
                    return $"No existe Este Detalle Pedido con id de pedido {detallePedido.id}";
                }

                bdTienda.tblDetallePedidoes.AddOrUpdate(detallePedido);
                bdTienda.SaveChanges();
                return $"Se actualizo  el Detalle deta con  id {detallePedido.id} ";
            }
            catch
            {
                throw;
            }
        }

        public string Eliminar()
        {
            try
            {
                tblDetallePedido _detallePedido = ConsultaXid(detallePedido.id);
                if(_detallePedido == null)
                {
                    return $"No existe Este Detalle Pedido con id de pedido {detallePedido.id}";
                }

                bdTienda.tblDetallePedidoes.Remove(_detallePedido);
                bdTienda.SaveChanges();
                return $"Se eliminó Detalle pedido {_detallePedido.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}