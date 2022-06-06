using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbAso
    {
        public int IdAso { get; set; }
        public int? IdAsoSoc { get; set; }
        public int? IdBnfco { get; set; }
        public string? CdMtrcaFncno { get; set; }
        public DateTime? DtAso { get; set; }
        public string? InStcoAso { get; set; }
        public string? InTipoExameOcpcl { get; set; }
        public string? InRsltoAso { get; set; }
        public string? DsAnexoAso { get; set; }
        public string? NmMdcoEmtne { get; set; }
        public decimal? NrCpfMdcoEmtne { get; set; }
        public decimal? NrNisMdcoEmtne { get; set; }
        public decimal? NrCrmMdcoEmtne { get; set; }
        public string? SgUfCrmMdcoEmtne { get; set; }
        public string? NmMdcoRspnl { get; set; }
        public decimal? NrCpfMdcoRspnl { get; set; }
        public decimal? NrCrmMdcoRspn { get; set; }
        public string? SgUfCrmMdcoRspnl { get; set; }
    }
}