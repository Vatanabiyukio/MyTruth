using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbTrmo
    {
        public int IdTrmo { get; set; }
        public int? IdRsptaFrmro { get; set; }
        public string? TxLgnda { get; set; }
        public DateTime? DtRspta { get; set; }
        public int? IdUser { get; set; }
    }
}