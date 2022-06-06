using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbLogAtrzoBb
    {
        public int IdAutorizacao { get; set; }
        public string? NmUsr { get; set; }
        public string? DscLoginUsr { get; set; }
        public string? CpfUsr { get; set; }
        public string? DsEmail { get; set; }
        public int TpAtdto { get; set; }
        public DateTime? DtInsercao { get; set; }
    }
}