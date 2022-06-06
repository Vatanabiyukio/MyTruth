using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbPrcdoDgnsoEscl
    {
        public int IdPrcdoDgnsoEscl { get; set; }
        public string CdPrcdoDgnsoEscl { get; set; } = null!;
        public string DsPrcdoDgnsoEscl { get; set; } = null!;
        public DateTime DtIncoVgnca { get; set; }
        public DateTime? DtFimVgnca { get; set; }
    }
}