using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbUor
    {
        public int Id { get; set; }
        public int? CdUor { get; set; }
        public int? CdLtcao { get; set; }
        public int? IdUfTrblo { get; set; }
        public int? IdMncpoTrblo { get; set; }
        public int? CdUorTrblo { get; set; }
        public string? NmUorTrblo { get; set; }
    }
}