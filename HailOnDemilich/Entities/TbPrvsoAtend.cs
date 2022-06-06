using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbPrvsoAtend
    {
        public int IdPrvsoAtend { get; set; }
        public int? IdClncaTpoAtdto { get; set; }
        public DateTime? DtPrvso { get; set; }
        public string? Medico { get; set; }
        public string? TxMsgem { get; set; }
    }
}