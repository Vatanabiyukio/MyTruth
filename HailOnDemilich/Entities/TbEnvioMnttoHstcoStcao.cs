using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbEnvioMnttoHstcoStcao
    {
        public int IdEnvioMnttoHstcoStcao { get; set; }
        public int? IdEnvioMntto { get; set; }
        public int? IdStcaoEnvioMntto { get; set; }
        public DateTime? DtEnvio { get; set; }
        public string? DsOcrca { get; set; }

        public virtual TbEnvioMntto? IdEnvioMnttoNavigation { get; set; }
        public virtual TbStcaoEnvioMntto? IdStcaoEnvioMnttoNavigation { get; set; }
    }
}