//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicketMidia.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_MODULO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_MODULO()
        {
            this.TB_FUNCAO = new HashSet<TB_FUNCAO>();
        }
    
        public int MOD_CD { get; set; }
        public string MOD_DESC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_FUNCAO> TB_FUNCAO { get; set; }
    }
}
