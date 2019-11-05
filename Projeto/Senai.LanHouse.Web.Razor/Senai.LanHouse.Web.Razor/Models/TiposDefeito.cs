using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.LanHouse.Web.Razor.Models
{
    public partial class TiposDefeito
    {
        public TiposDefeito()
        {
            RegistrosDefeitos = new HashSet<RegistrosDefeitos>();
        }

        public int Id { get; set; }
        [StringLength(maximumLength:100)]
        public string Nome { get; set; }

        public ICollection<RegistrosDefeitos> RegistrosDefeitos { get; set; }
    }
}
