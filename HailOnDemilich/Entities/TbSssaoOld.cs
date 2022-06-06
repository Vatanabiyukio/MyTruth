using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbSssaoOld
    {
        public int IdSssao { get; set; }
        public int? NrOrdem { get; set; }
        public string? TxSssao { get; set; }
        public int? TpSssao { get; set; }
        public int? IdFrmro { get; set; }
        public int? IdSssaoPai { get; set; }
        public int? TipPrncoUsro { get; set; }
        public int? TpSssaoChckEps { get; set; }
        public int? TpSssaoSxo { get; set; }
    }
}