using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbArqvo
    {
        public TbArqvo()
        {
            TbEnvioMnttoAsos = new HashSet<TbEnvioMnttoAso>();
        }

        public int IdArqvo { get; set; }
        public int IdBnfco { get; set; }
        public int IdFmro { get; set; }
        public string? NomArqvo { get; set; }
        public string? TpArqvo { get; set; }
        public int? QtdBtes { get; set; }
        public string? DscLclArqvo { get; set; }
        public DateTime? DtImptoArqvo { get; set; }
        public int? IdRsptaFrmroAso { get; set; }
        public bool? InCfrdo { get; set; }

        public virtual ICollection<TbEnvioMnttoAso> TbEnvioMnttoAsos { get; set; }
    }
}