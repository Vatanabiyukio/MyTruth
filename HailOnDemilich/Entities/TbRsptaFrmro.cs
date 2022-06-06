using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbRsptaFrmro
    {
        public TbRsptaFrmro()
        {
            TbEnvioMnttoIdRsptaFrmroAsoNavigations = new HashSet<TbEnvioMntto>();
            TbEnvioMnttoIdRsptaFrmroPrpalNavigations = new HashSet<TbEnvioMntto>();
            TbRsptaFrmroMdicos = new HashSet<TbRsptaFrmroMdico>();
        }

        public int IdRsptaFrmro { get; set; }
        public int? IdFrmro { get; set; }
        public int? IdBnfro { get; set; }
        public int? IdMdico { get; set; }
        public int? InStcao { get; set; }
        public DateTime? DtExame { get; set; }
        public int? InEmpsa { get; set; }
        public int? IdLtcao { get; set; }
        public int? IdCargo { get; set; }
        public int? VrTempoFncao { get; set; }
        public string? NrTlfne { get; set; }
        public DateTime? DtIncso { get; set; }
        public int? IdExme { get; set; }
        public int? IdUsudgt { get; set; }
        public int? IdRsptaFrmroPrnpl { get; set; }
        public string? NrMtrla { get; set; }
        public string? NrCpf { get; set; }
        public string? SgUf { get; set; }
        public string? NmBnfro { get; set; }
        public int? InTipoUsrioDgtco { get; set; }
        public int? IdUsrioAltco { get; set; }
        public DateTime? DtAltco { get; set; }
        public int? InStcaoSoc { get; set; }
        public string? LoginUsrioDgtco { get; set; }
        public string? NomeUsrioDgtco { get; set; }
        public string? LoginUsrioAltco { get; set; }
        public string? NomeUsrioAltco { get; set; }
        public string? NrCnpj { get; set; }
        public string? NrRg { get; set; }
        public int? IdCntto { get; set; }
        public int? NrUor { get; set; }

        public virtual ICollection<TbEnvioMntto> TbEnvioMnttoIdRsptaFrmroAsoNavigations { get; set; }
        public virtual ICollection<TbEnvioMntto> TbEnvioMnttoIdRsptaFrmroPrpalNavigations { get; set; }
        public virtual ICollection<TbRsptaFrmroMdico> TbRsptaFrmroMdicos { get; set; }
    }
}