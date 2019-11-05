using System.ComponentModel.DataAnnotations;

namespace Senai.LanHouse.Web.Razor.Models
{
    [Display(Name ="Registro de defeitos")]
    public partial class RegistrosDefeitos
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="A data em que o equipamento teve defeito é obrigatoria")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data do defeito")]
        public System.DateTime DataDefeito { get; set; }

        [Display(Name = "Equipamento")]
        public int IdEquipamento { get; set; }

        [Display(Name = "Defeito")]//cadastrar
        public int IdDefeito { get; set; }

        [Display(Name = "Observação")]
        [StringLength(maximumLength: 500,ErrorMessage ="A Observação excede o numero maximo de caracteres")]
        public string Observacao { get; set; }

        [Display(Name = "Defeito")]//visualizar
        public TiposDefeito IdDefeitoNavigation { get; set; }

        [Display(Name = "Equipamento")]
        public Equipamentos IdEquipamentoNavigation { get; set; }
    }
}
