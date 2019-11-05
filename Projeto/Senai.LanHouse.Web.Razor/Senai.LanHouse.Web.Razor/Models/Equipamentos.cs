using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.LanHouse.Web.Razor.Models
{
    public partial class Equipamentos
    {
        public Equipamentos()
        {
            RegistrosDefeitos = new HashSet<RegistrosDefeitos>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage ="O Nome do equipamento é obrigatório")]
        [StringLength(maximumLength:100,ErrorMessage = "O nome do equipamento excede o tamanho maximo")]
        public string Nome { get; set; }

        public ICollection<RegistrosDefeitos> RegistrosDefeitos { get; set; }
    }
}
