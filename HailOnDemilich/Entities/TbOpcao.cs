using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbOpcao
    {
        public int IdOpcao { get; set; }
        public int? IdClnas { get; set; }
        public int? NrOrdem { get; set; }
        public string? TxLgnda { get; set; }
        public string? NrValor { get; set; }
        public int? NrCasasDcmis { get; set; }
        public int? NrMaxCrtes { get; set; }
        public int? VlMnimo { get; set; }
        public int? VlMximo { get; set; }
        public string? ExDpdca { get; set; }
        public string? ExVlorOpc { get; set; }
        public int? VlIndcoRsldoEscal { get; set; }
    }
}