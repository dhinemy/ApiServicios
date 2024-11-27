using ApiTiendaAccesorios.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace ApiTiendaAccesorios.Clases
{
    public class clsFormaEntrega
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblFormaEntrega formaEntrega { get; set; }

        public List<tblFormaEntrega> LlenarComboFormaEntrega()
        {
            return bdTienda.tblFormaEntregas.ToList();
        }


        // Método para consultar una forma de entrega por ID
        public tblFormaEntrega ConsultarXid(int id)
        {
            return bdTienda.tblFormaEntregas.FirstOrDefault(fe => fe.id == id);
        }

        // Método para insertar una nueva forma de entrega
        public string Insertar()
        {
            try
            {
                bdTienda.tblFormaEntregas.Add(formaEntrega);
                bdTienda.SaveChanges();
                return $"Se insertó correctamente la forma de entrega con ID {formaEntrega.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para actualizar una forma de entrega existente
        public string Actualizar()
        {
            try
            {
                var _formaEntrega = ConsultarXid(formaEntrega.id);
                if (_formaEntrega == null)
                {
                    return $"No existe una forma de entrega con el ID {formaEntrega.id}";
                }

                bdTienda.tblFormaEntregas.AddOrUpdate(formaEntrega);
                bdTienda.SaveChanges();
                return $"Se actualizó correctamente la forma de entrega con ID {formaEntrega.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para eliminar una forma de entrega existente
        public string Eliminar()
        {
            try
            {
                var _formaEntrega = ConsultarXid(formaEntrega.id);
                if (_formaEntrega == null)
                {
                    return $"No existe una forma de entrega con el ID {formaEntrega.id}";
                }

                bdTienda.tblFormaEntregas.Remove(_formaEntrega);
                bdTienda.SaveChanges();
                return $"Se eliminó correctamente la forma de entrega con ID {formaEntrega.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
