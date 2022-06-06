using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbCampo
    {
        public TbCampo()
        {
            TbEnvioMnttoAsoExames = new HashSet<TbEnvioMnttoAsoExame>();
        }

        public int IdCampo { get; set; }
        public int? IdSssao { get; set; }
        public int? CdCampo { get; set; }
        public int? NrOrdem { get; set; }
        public string? TxCampo { get; set; }
        public string? InExbirDscao { get; set; }
        public string? CdAlinhaDescao { get; set; }
        public int? NrTmnhoDescao { get; set; }
        public string? TxInsto { get; set; }
        public string? InExibirInsto { get; set; }
        public string? CdAlinhaInsto { get; set; }
        public int? NrTmnhoInsto { get; set; }
        public int? NrTmnhoRspta { get; set; }
        public string? InObrgo { get; set; }
        public string? InUmaOpcoLinha { get; set; }
        public int? TpRspta { get; set; }
        public string? InRsptaPrtte { get; set; }
        public int? TpAprco { get; set; }
        public string? TpSxo { get; set; }
        public int? NrIddeIncal { get; set; }
        public int? NrIddeFnal { get; set; }
        public string? InEnviaEscal { get; set; }
        public int? IdPrctoDgncoEscal { get; set; }
        public bool? InRsptaAso { get; set; }
        public int? IdTipoIndorCampoMntto { get; set; }
        public int? IdCampoDataEscal { get; set; }
        public int? IdCampoObscoEscal { get; set; }
        public int? IdCampoAgrtoEscal { get; set; }
        public int? IdCampoOrdemExameEscal { get; set; }

        public virtual TbPrctoDgncoEscal? IdPrctoDgncoEscalNavigation { get; set; }
        public virtual TbTipoIndorCampoMntto? IdTipoIndorCampoMnttoNavigation { get; set; }
        public virtual ICollection<TbEnvioMnttoAsoExame> TbEnvioMnttoAsoExames { get; set; }
    }
}