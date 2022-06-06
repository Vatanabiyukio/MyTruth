using System;
using System.Collections.Generic;

namespace HailOnDemilich.Entities
{
    public partial class TbTipoIndorCampoMntto
    {
        public TbTipoIndorCampoMntto()
        {
            TbCampos = new HashSet<TbCampo>();
        }

        public int IdTipoIndorCampoMntto { get; set; }
        public string? DsTipoIndorCampoMntto { get; set; }

        public virtual ICollection<TbCampo> TbCampos { get; set; }
    }
}