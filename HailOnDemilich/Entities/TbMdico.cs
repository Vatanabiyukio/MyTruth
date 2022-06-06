using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbMdico
    {
        public int IdMdico { get; set; }
        public string? NmMdico { get; set; }
        public string? NrCrm { get; set; }
        public string? SgUfCrm { get; set; }
        public string? NrCpf { get; set; }
        public string? OrgemCdtro { get; set; }
        public DateTime? DtCdtro { get; set; }
    }
}