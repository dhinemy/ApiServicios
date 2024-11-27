using ApiTiendaAccesorios.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace ApiTiendaAccesorios.Clases
{
    public class clsFormaPago
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblFormaPago formaPago { get; set; }


        public List<tblFormaPago> LlenarComboFormadepago()
        {
            return bdTienda.tblFormaPagoes.ToList();
        }
    }
}
