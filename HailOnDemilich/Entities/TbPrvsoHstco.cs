using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbPrvsoHstco
    {
        public int IdPrvsoHstco { get; set; }
        public int? IdBnfco { get; set; }
        public int? IdUf { get; set; }
        public int? IdMncpo { get; set; }
        public int? IdLtcao { get; set; }
        public string? InStcao { get; set; }
        public string? TxMtvoClmto { get; set; }
        public int? IdClncaTpoAtdto { get; set; }
        public int? IdPrvsoAtend { get; set; }
        public DateTime? DtInclusao { get; set; }
        public int? IdPrvso { get; set; }
    }
}