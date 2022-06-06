using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbTrnsa
    {
        public int IdTrnsa { get; set; }
        public int? IdStcoTrnsa { get; set; }
        public int? IdAso { get; set; }
        public string? DsObsroTrnsa { get; set; }
        public DateTime? DhTrnsa { get; set; }
    }
}