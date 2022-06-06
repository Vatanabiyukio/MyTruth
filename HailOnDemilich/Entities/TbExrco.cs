using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbExrco
    {
        public int IdExrco { get; set; }
        public int? CdAno { get; set; }
        public string? DsExrco { get; set; }
        public int? StExrco { get; set; }
        public DateTime? DtVldco { get; set; }
    }
}