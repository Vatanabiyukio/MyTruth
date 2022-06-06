using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbClnasOld
    {
        public int IdClnas { get; set; }
        public int? NrOrdem { get; set; }
        public int? IdCampo { get; set; }
        public int? CdClnas { get; set; }
        public string? TxClnas { get; set; }
        public string? InExbir { get; set; }
        public string? CdAlnha { get; set; }
        public string? InRsptaPrtte { get; set; }
        public int? NrTmnho { get; set; }
        public int? TpOpcao { get; set; }
        public string? InUmaOpcoLinha { get; set; }
        public string? VlMin { get; set; }
        public string? VlMax { get; set; }
    }
}