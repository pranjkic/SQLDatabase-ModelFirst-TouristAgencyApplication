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
    
    public partial class KlijentKojiPoslujeSaFilijalom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KlijentKojiPoslujeSaFilijalom()
        {
            this.Ugovors = new HashSet<Ugovor>();
        }
    
        public int KlijentId { get; set; }
        public int FilijalaId { get; set; }
        public int FilijalaTuristickaAgencijaId { get; set; }
    
        public virtual Klijent Klijent { get; set; }
        public virtual Filijala Filijala { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ugovor> Ugovors { get; set; }
    }
}
