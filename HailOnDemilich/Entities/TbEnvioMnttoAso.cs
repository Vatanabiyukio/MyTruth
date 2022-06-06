using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbEnvioMnttoAso
    {
        public TbEnvioMnttoAso()
        {
            TbEnvioMnttoAsoExames = new HashSet<TbEnvioMnttoAsoExame>();
        }

        public int IdEnvioMnttoAso { get; set; }
        public int? IdEnvioMntto { get; set; }
        public int? IdRsptaFrmroAso { get; set; }
        public int? IdTipoRstdoAso { get; set; }
        public int? IdArqvo { get; set; }
        public DateTime? DtEmsaoAso { get; set; }
        public DateTime? DtExame { get; set; }
        public string? NmMdicoEmtteAso { get; set; }
        public string? NrCrmMdicoEmtteAso { get; set; }
        public string? SgUfCrmMdicoEmtteAso { get; set; }
        public string? NrCpfMdicoCddorPcmso { get; set; }
        public string? NmMdicoCddorPcmso { get; set; }
        public string? NrCrmMdicoCddorPcmso { get; set; }
        public string? SgUfCrmMdicoCddorPcmso { get; set; }

        public virtual TbArqvo? IdArqvoNavigation { get; set; }
        public virtual TbEnvioMntto? IdEnvioMnttoNavigation { get; set; }
        public virtual TbTipoRstdoAso? IdTipoRstdoAsoNavigation { get; set; }
        public virtual ICollection<TbEnvioMnttoAsoExame> TbEnvioMnttoAsoExames { get; set; }
    }
}