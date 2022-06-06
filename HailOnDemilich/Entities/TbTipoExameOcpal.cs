using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbTipoExameOcpal
    {
        public TbTipoExameOcpal()
        {
            TbEnvioMnttos = new HashSet<TbEnvioMntto>();
        }

        public int IdTipoExameOcpal { get; set; }
        public int? CdTipoExameOcpal { get; set; }
        public string? DsTipoExameOcpal { get; set; }

        public virtual ICollection<TbEnvioMntto> TbEnvioMnttos { get; set; }
    }
}