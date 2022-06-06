using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbLtcao
    {
        public int IdLtcao { get; set; }
        public string? NomLtcao { get; set; }
        public int? CdLtcao { get; set; }
        public int? IdUf { get; set; }
        public int? IdMncpo { get; set; }
        public int? IdCntto { get; set; }
        public string? NrCnpj { get; set; }
        public bool? InAdcno { get; set; }
    }
}