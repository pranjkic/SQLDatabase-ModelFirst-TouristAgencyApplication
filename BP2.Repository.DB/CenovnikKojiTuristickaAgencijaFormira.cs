//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BP2.Repository.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class CenovnikKojiTuristickaAgencijaFormira
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CenovnikKojiTuristickaAgencijaFormira()
        {
            this.Cenovnik_Putovanje = new HashSet<Cenovnik_Putovanje>();
        }
    
        public double KoeficijentNaplate { get; set; }
        public int TuristickaAgencijaId { get; set; }
        public int CenovnikId { get; set; }
    
        public virtual TuristickaAgencija TuristickaAgencija { get; set; }
        public virtual Cenovnik Cenovnik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cenovnik_Putovanje> Cenovnik_Putovanje { get; set; }
    }
}
