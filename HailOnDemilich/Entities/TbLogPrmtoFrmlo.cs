using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbLogPrmtoFrmlo
    {
        public int IdLog { get; set; }
        public int IdUsudgt { get; set; }
        public string TxUsudgt { get; set; } = null!;
        public int IdBnfro { get; set; }
        public int IdFrmro { get; set; }
        public int? IdRspstaFrmro { get; set; }
        public string? StcaoFrmroRspsta { get; set; }
        public string? TxStcao { get; set; }
        public DateTime? DtRegto { get; set; }
    }
}