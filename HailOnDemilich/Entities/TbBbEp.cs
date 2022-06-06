using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HailOnDemilich.Entities
{
    public partial class TbBbEp
    {
        [Key] public string Cpf { get; set; } = null!;
        public int Competencia { get; set; }
        public int MatriculaFuncional { get; set; }
        public string Nome { get; set; } = null!;
        public int Prefixo { get; set; }
        public string Dependencia { get; set; } = null!;
        public string Uf { get; set; } = null!;
        public int CodComiss { get; set; }
        public string Comissao { get; set; } = null!;
        public string Municipio { get; set; } = null!;
        public DateTime Nascimento { get; set; }
        public DateTime DataPosse { get; set; }
        public DateTime Cmpt { get; set; }
        public string? Flag { get; set; }
        public string Genero { get; set; } = null!;
    }
}