using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbEnvioMnttoAsoExame
    {
        public int IdEnvioMnttoAsoExame { get; set; }
        public int? IdEnvioMnttoAso { get; set; }
        public int? IdCampo { get; set; }
        public int? IdPrctoDgncoEscal { get; set; }
        public int? IdTipoRstdoExame { get; set; }
        public string? CdPrctoDgncoEscal { get; set; }
        public DateTime? DtExame { get; set; }
        public int? VlRspta { get; set; }
        public int? CdOrdemExame { get; set; }
        public string? DsRspta { get; set; }

        public virtual TbCampo? IdCampoNavigation { get; set; }
        public virtual TbEnvioMnttoAso? IdEnvioMnttoAsoNavigation { get; set; }
        public virtual TbPrctoDgncoEscal? IdPrctoDgncoEscalNavigation { get; set; }
        public virtual TbTipoRstdoExame? IdTipoRstdoExameNavigation { get; set; }
    }
}