
namespace SunOnDemilich.Entities
{
    public partial class TbBbEp
    {
        public int Competencia { get; set; }
        public string Cpf { get; set; } = null!;
        public int MatriculaFuncional { get; set; }
        public string Nome { get; set; } = null!;
        public int Prefixo { get; set; }
        public string Dependencia { get; set; } = null!;
        public string Uf { get; set; } = null!;
        public int CodComiss { get; set; }
        public string Comissao { get; set; } = null!;
        public string Municipio { get; set; } = null!;
        public DateOnly Nascimento { get; set; }
        public DateOnly DataPosse { get; set; }
        public DateOnly Cmpt { get; set; }
        public string? Flag { get; set; }
        public string Genero { get; set; } = null!;
    }
}
