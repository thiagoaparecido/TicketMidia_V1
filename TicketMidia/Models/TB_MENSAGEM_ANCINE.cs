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
    
    public partial class TB_MENSAGEM_ANCINE
    {
        public System.DateTime MSA_DT_MSG { get; set; }
        public System.DateTime MSA_DT_HORA_MSG { get; set; }
        public long BIL_ID { get; set; }
        public string SAL_CD_ANCINE { get; set; }
        public Nullable<long> SEA_ID { get; set; }
        public Nullable<System.DateTime> SEA_DT_HR_INICIO { get; set; }
        public string MSA_TP_MSG { get; set; }
        public string MSA_CD_MSG { get; set; }
        public string MSA_TXT_MSG { get; set; }
    
        public virtual TB_BILHETERIA TB_BILHETERIA { get; set; }
        public virtual TB_SALA TB_SALA { get; set; }
        public virtual TB_SESSAO_ANCINE TB_SESSAO_ANCINE { get; set; }
    }
}
