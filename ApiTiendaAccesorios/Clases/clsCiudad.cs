using ApiTiendaAccesorios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaAccesorios.Clases
{
    public class clsCiudad
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblCiudad tblCiudad { get; set; }

        public List<tblCiudad> LlenarComboCiudad()
        {
            return bdTienda.tblCiudads.ToList();
        }
    }
}