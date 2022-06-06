using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbFrmro
    {
        public int IdFrmro { get; set; }
        public int? CdFrmro { get; set; }
        public string? TxFrmro { get; set; }
        public DateTime? DtInial { get; set; }
        public DateTime? DtFinal { get; set; }
        public int? TpFrmro { get; set; }
        public string? StFrmro { get; set; }
        public int? NrAno { get; set; }
        public string? ExDpdca { get; set; }
        public int? IdEmpsa { get; set; }
    }
}