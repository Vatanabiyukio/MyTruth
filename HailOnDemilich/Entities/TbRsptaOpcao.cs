using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbRsptaOpcao
    {
        public int IdRsptaOpcao { get; set; }
        public int? IdRsptaCampo { get; set; }
        public int? IdOpcao { get; set; }
        public int? VlRspta { get; set; }
        public string? TxJstva { get; set; }
        public string? TxObsco { get; set; }
        public int? IdSssao { get; set; }
        public int? IdBnfro { get; set; }
    }
}