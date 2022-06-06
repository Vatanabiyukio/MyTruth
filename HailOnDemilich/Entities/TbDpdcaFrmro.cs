using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbDpdcaFrmro
    {
        public int IdDpdca { get; set; }
        public int? IdFrmro { get; set; }
        public int? IdSssao { get; set; }
        public int? IdOpcao { get; set; }
        public int? IdFrmroDpdca { get; set; }
        public int? IdSssaoDpdca { get; set; }
        public int? IdOpcaoDpdca { get; set; }
        public string? TxAco { get; set; }
        public string? TxMnsgmNtfco { get; set; }
        public int? TipRfrnaVnclo { get; set; }
        public bool? InMnsgmInfro { get; set; }
        public int? IdCampoDpdca { get; set; }
    }
}