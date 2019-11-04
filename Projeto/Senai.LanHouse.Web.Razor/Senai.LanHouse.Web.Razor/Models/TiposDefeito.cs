using System;
using System.Collections.Generic;

namespace Senai.LanHouse.Web.Razor.Models
{
    public partial class TiposDefeito
    {
        public TiposDefeito()
        {
            RegistrosDefeitos = new HashSet<RegistrosDefeitos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<RegistrosDefeitos> RegistrosDefeitos { get; set; }
    }
}
