using ApiTiendaAccesorios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaAccesorios.Clases
{
    public class clsTipoDocumento
    {
        private bdTiendaAccesoriosEntities bdTienda = new bdTiendaAccesoriosEntities();

        public tblTipoDocumento tipoDocumento { get; set; }

        public List<tblTipoDocumento> LlenarComboTipoDocumento()
        {
            return bdTienda.tblTipoDocumentoes.ToList();
        }
    }
}