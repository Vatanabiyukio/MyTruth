using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbEnvioMntto
    {
        public TbEnvioMntto()
        {
            TbEnvioMnttoAsos = new HashSet<TbEnvioMnttoAso>();
            TbEnvioMnttoHstcoStcaos = new HashSet<TbEnvioMnttoHstcoStcao>();
        }

        public int IdEnvioMntto { get; set; }
        public int? IdTipoExameOcpal { get; set; }
        public int? IdRsptaFrmroPrpal { get; set; }
        public int? IdRsptaFrmroAso { get; set; }
        public int? IdStcaoEnvioMntto { get; set; }
        public string? NrMtclaFncal { get; set; }
        public string? NmFncro { get; set; }
        public DateTime? DtIncsoRgsto { get; set; }
        public int? SeqExameBb { get; set; }

        public virtual TbRsptaFrmro? IdRsptaFrmroAsoNavigation { get; set; }
        public virtual TbRsptaFrmro? IdRsptaFrmroPrpalNavigation { get; set; }
        public virtual TbStcaoEnvioMntto? IdStcaoEnvioMnttoNavigation { get; set; }
        public virtual TbTipoExameOcpal? IdTipoExameOcpalNavigation { get; set; }
        public virtual ICollection<TbEnvioMnttoAso> TbEnvioMnttoAsos { get; set; }
        public virtual ICollection<TbEnvioMnttoHstcoStcao> TbEnvioMnttoHstcoStcaos { get; set; }
    }
}