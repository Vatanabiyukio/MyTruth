using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbStcaoEnvioMntto
    {
        public TbStcaoEnvioMntto()
        {
            TbEnvioMnttoHstcoStcaos = new HashSet<TbEnvioMnttoHstcoStcao>();
            TbEnvioMnttos = new HashSet<TbEnvioMntto>();
        }

        public int IdStcaoEnvioMntto { get; set; }
        public string? DsStcaoEnvioMntto { get; set; }

        public virtual ICollection<TbEnvioMnttoHstcoStcao> TbEnvioMnttoHstcoStcaos { get; set; }
        public virtual ICollection<TbEnvioMntto> TbEnvioMnttos { get; set; }
    }
}