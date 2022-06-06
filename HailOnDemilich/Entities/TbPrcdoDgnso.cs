using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbPrcdoDgnso
    {
        public int IdPrcdoDgnso { get; set; }
        public int? IdAso { get; set; }
        public int? IdPrcdoDgnsoEscl { get; set; }
        public string? InOrdemExame { get; set; }
        public string? InRslto { get; set; }
        public DateTime? DtExame { get; set; }
        public string? DsObsroPrcdoDgnso { get; set; }
    }
}