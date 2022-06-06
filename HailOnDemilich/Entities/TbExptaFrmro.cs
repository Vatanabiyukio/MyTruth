using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbExptaFrmro
    {
        public int IdExpta { get; set; }
        public int IdFrmro { get; set; }
        public int CdFrmro { get; set; }
        public int IdSessao { get; set; }
        public int IdOpcao { get; set; }
        public int InPscaoX { get; set; }
        public int InPscaoY { get; set; }
        public string? TxCampo { get; set; }
    }
}