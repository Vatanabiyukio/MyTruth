using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbTipoRstdoExame
    {
        public TbTipoRstdoExame()
        {
            TbEnvioMnttoAsoExames = new HashSet<TbEnvioMnttoAsoExame>();
        }

        public int IdTipoRstdoExame { get; set; }
        public int? CdTipoRstdoExame { get; set; }
        public string? DsTipoRstdoExame { get; set; }

        public virtual ICollection<TbEnvioMnttoAsoExame> TbEnvioMnttoAsoExames { get; set; }
    }
}