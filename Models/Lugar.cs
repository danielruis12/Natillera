//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Natillera.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Lugar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lugar()
        {
            this.Evento_Lugar = new HashSet<Evento_Lugar>();
        }
    
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Capacidad { get; set; }
        public decimal CostoHora { get; set; }
        [JsonIgnore]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evento_Lugar> Evento_Lugar { get; set; }
    }
}
