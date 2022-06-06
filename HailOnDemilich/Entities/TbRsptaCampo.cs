using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbRsptaCampo
    {
        public int IdRsptaCampo { get; set; }
        public int? IdRsptaFrmro { get; set; }
        public int? IdCampo { get; set; }
        public int? VlRspta { get; set; }
        public int? IdSssao { get; set; }
        public int? IdBnfro { get; set; }
    }
}