using ApiTiendaAccesorios.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ApiTiendaAccesorios.Clases
{
    public class clsGarantia
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblGarantia garantia { get; set; }

        // Método para consultar una garantía por ID
        public tblGarantia ConsultarXid(int id)
        {
            return bdTienda.tblGarantias.FirstOrDefault(g => g.id == id);
        }

        // Método para insertar una nueva garantía
        public string Insertar()
        {
            try
            {
                bdTienda.tblGarantias.Add(garantia);
                bdTienda.SaveChanges();
                return $"Se insertó correctamente la garantía con ID {garantia.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para actualizar una garantía existente
        public string Actualizar()
        {
            try
            {
                var _garantia = ConsultarXid(garantia.id);
                if (_garantia == null)
                {
                    return $"No existe una garantía con el ID {garantia.id}";
                }

                bdTienda.tblGarantias.AddOrUpdate(garantia);
                bdTienda.SaveChanges();
                return $"Se actualizó correctamente la garantía con ID {garantia.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para eliminar una garantía existente
        public string Eliminar()
        {
            try
            {
                var _garantia = ConsultarXid(garantia.id);
                if (_garantia == null)
                {
                    return $"No existe una garantía con el ID {garantia.id}";
                }

                bdTienda.tblGarantias.Remove(_garantia);
                bdTienda.SaveChanges();
                return $"Se eliminó correctamente la garantía con ID {garantia.id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
