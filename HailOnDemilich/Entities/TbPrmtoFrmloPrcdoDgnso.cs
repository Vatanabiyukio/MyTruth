using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbPrmtoFrmloPrcdoDgnso
    {
        public int IdPrmtoFrmloPrcdoDgnso { get; set; }
        public int IdPrcdoDgnsoEscl { get; set; }
        public int? IdCampo { get; set; }
        public DateTime DtIncoVgnca { get; set; }
        public DateTime? DtFimVgnca { get; set; }
    }
}