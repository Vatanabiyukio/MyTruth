using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbClnca
    {
        public int IdClnca { get; set; }
        public string? NomClnca { get; set; }
        public int? IdUf { get; set; }
        public int? IdMncpo { get; set; }
        public bool? InAtivo { get; set; }
    }
}