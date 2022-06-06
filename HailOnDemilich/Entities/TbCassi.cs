using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbCassi
    {
        public int Id { get; set; }
        public int AnoEps { get; set; }
        public string NumCpf { get; set; } = null!;
        public long MatSoc { get; set; }
        public int LotSoc { get; set; }
        public DateTime? DtAdmissao { get; set; }
        public int NumPess { get; set; }
        public string NomeEmpr { get; set; } = null!;
        public string UnidOrganizacional { get; set; } = null!;
        public string NomeCargo { get; set; } = null!;
        public int NumCargo { get; set; }
        public int? GerenciaExec { get; set; }
        public string CentroCusto { get; set; } = null!;
        public string Uf { get; set; } = null!;
        public DateTime? DtUltimoExame { get; set; }
        public string Sexo { get; set; } = null!;
        public DateTime? DtNasc { get; set; }
        public int Idade { get; set; }
        public string Periodicidade { get; set; } = null!;
        public int? Situacao { get; set; }
        public bool? AsoEntregue { get; set; }
        public DateTime? DtExame { get; set; }
        public bool? Resul { get; set; }
    }
}