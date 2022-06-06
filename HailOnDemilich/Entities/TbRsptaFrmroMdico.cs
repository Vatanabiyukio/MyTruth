using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbRsptaFrmroMdico
    {
        public int IdRsptaFrmroMdico { get; set; }
        public int? IdRsptaFrmro { get; set; }
        public int? IdTipoMdico { get; set; }
        public string? NmMdico { get; set; }
        public string? NrCrm { get; set; }
        public string? SgUfCrm { get; set; }
        public string? NrCpf { get; set; }

        public virtual TbRsptaFrmro? IdRsptaFrmroNavigation { get; set; }
    }
}