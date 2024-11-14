using ApiTiendaAccesorios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaAccesorios.Clases
{
    public class clsTipoProducto
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblTipoProducto tipoDocumento { get; set; }

        public List<tblTipoProducto> LlenarComboTipoProducto()
        {
            return bdTienda.tblTipoProductoes.ToList();
        }
    }
}