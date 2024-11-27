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
    
    public partial class tblDetallePedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDetallePedido()
        {
            this.tblGarantias = new HashSet<tblGarantia>();
        }
    
        public int id { get; set; }
        public int id_pedido { get; set; }
        public int id_producto { get; set; }
        public Nullable<double> descuento { get; set; }
        public double vr_unitario { get; set; }
        public int cantidad { get; set; }
        public Nullable<double> iva { get; set; }
        public Nullable<System.DateTime> fecha_fin_garantia { get; set; }
        public double total { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGarantia> tblGarantias { get; set; }
        [JsonIgnore]
        public virtual tblPedido tblPedido { get; set; }
        [JsonIgnore]
        public virtual tblProducto tblProducto { get; set; }
    }
}
