using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbPrctoDgncoEscal
    {
        public TbPrctoDgncoEscal()
        {
            TbCampos = new HashSet<TbCampo>();
            TbEnvioMnttoAsoExames = new HashSet<TbEnvioMnttoAsoExame>();
        }

        public int IdPrctoDgncoEscal { get; set; }
        public string? CdPrctoDgncoEscal { get; set; }
        public string? DsPrctoDgncoEscal { get; set; }
        public DateTime DtIncioVgcia { get; set; }
        public DateTime? DtFimVgcia { get; set; }
        public bool? InFvrto { get; set; }

        public virtual ICollection<TbCampo> TbCampos { get; set; }
        public virtual ICollection<TbEnvioMnttoAsoExame> TbEnvioMnttoAsoExames { get; set; }
    }
}