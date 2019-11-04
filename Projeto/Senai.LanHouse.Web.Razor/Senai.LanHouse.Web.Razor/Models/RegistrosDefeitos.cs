using System;
using System.Collections.Generic;

namespace Senai.LanHouse.Web.Razor.Models
{
    public partial class RegistrosDefeitos
    {
        public int Id { get; set; }
        public DateTime DataDefeito { get; set; }
        public int IdEquipamento { get; set; }
        public int IdDefeito { get; set; }
        public string Observacao { get; set; }

        public TiposDefeito IdDefeitoNavigation { get; set; }
        public Equipamentos IdEquipamentoNavigation { get; set; }
    }
}
