using System.ComponentModel.DataAnnotations;

namespace Senai.LanHouse.Web.Razor.Models
{
    public partial class Usuarios
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="O email é obrigatorio")]
        [StringLength(maximumLength:100,ErrorMessage = "O email excede o tamanho maximo")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A senha é obrigatoria")]
        [StringLength(maximumLength: 100, ErrorMessage = "A senha excede o tamanho maximo")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
