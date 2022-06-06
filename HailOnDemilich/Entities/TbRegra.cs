using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbRegra
    {
        public int IdRegra { get; set; }
        public int IdRegraSoc { get; set; }
        public int IdExrco { get; set; }
        public string? DsTipo { get; set; }
        public string? DsRegra { get; set; }
        public DateTime? DtVldco { get; set; }
        public int? StRegra { get; set; }
        public int? IdCntto { get; set; }
    }
}