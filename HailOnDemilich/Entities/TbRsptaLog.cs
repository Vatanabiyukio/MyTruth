using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbRsptaLog
    {
        public int IdRsptaLog { get; set; }
        public int? IdFrmro { get; set; }
        public int? IdBnfro { get; set; }
        public int? IdSssao { get; set; }
        public DateTime? DtPrec { get; set; }
    }
}