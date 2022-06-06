using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbDpdca
    {
        public int IdDpdca { get; set; }
        public int? IdCampo { get; set; }
        public int? IdDpdcaCampo { get; set; }
        public int? IdOpcao { get; set; }
    }
}