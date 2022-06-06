using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbFrmroLog
    {
        public int IdLog { get; set; }
        public int? IdUsrioAltco { get; set; }
        public string? NmUsrioAltco { get; set; }
        public int? IdFrmroDe { get; set; }
        public int? IdFrmroPara { get; set; }
        public string? TxAcao { get; set; }
        public DateTime? DtAltco { get; set; }
    }
}