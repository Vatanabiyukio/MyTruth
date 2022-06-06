using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbPrvso
    {
        public int IdBnfco { get; set; }
        public string? NrMatriculca { get; set; }
        public string? NrCpf { get; set; }
        public string? NomBnfco { get; set; }
        public int? IdUf { get; set; }
        public int? IdMncpo { get; set; }
        public int? IdLtcao { get; set; }
        public int? CdLtcao { get; set; }
        public int? IdCrgo { get; set; }
        public string? InStcao { get; set; }
        public string? TxMtvoClmto { get; set; }
        public string? InAgndu { get; set; }
        public string? InFrmro { get; set; }
        public int? IdClncaTpoAtdto { get; set; }
        public int? IdPrvsoAtend { get; set; }
        public DateTime? DtInclusao { get; set; }
        public int? InTipoEps { get; set; }
        public int? IdTpoAtdtoEvntal { get; set; }
        public DateTime? DtAteto { get; set; }
        public string? TxObsao { get; set; }
        public int? IdUfDstno { get; set; }
        public string? InCndo { get; set; }
        public int? IdUfPrvso { get; set; }
        public int? IdLtcaoPrvso { get; set; }
        public int IdExrco { get; set; }
        public int IdPrvso { get; set; }
        public int? IdCntto { get; set; }
        public string? DsEmail { get; set; }
        public DateTime? DtNscto { get; set; }
        public int? IdUor { get; set; }
    }
}