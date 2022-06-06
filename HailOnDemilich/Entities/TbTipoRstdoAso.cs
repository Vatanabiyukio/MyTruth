using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbTipoRstdoAso
    {
        public TbTipoRstdoAso()
        {
            TbEnvioMnttoAsos = new HashSet<TbEnvioMnttoAso>();
        }

        public int IdTipoRstdoAso { get; set; }
        public int? CdTipoRstdoAso { get; set; }
        public string? DsTipoRstdoAso { get; set; }

        public virtual ICollection<TbEnvioMnttoAso> TbEnvioMnttoAsos { get; set; }
    }
}