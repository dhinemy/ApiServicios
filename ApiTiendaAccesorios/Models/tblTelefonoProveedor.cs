//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiTiendaAccesorios.Models
{
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    
    public partial class tblTelefonoProveedor
    {
        public int id { get; set; }
        public int id_proveedor { get; set; }
        public string telefono { get; set; }
        public bool activo { get; set; }
        [JsonIgnore]
        public virtual tblProveedor tblProveedor { get; set; }
    }
}
