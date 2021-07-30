using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        [Required (ErrorMessage = "Nome é campo obrigatório")]
        [StringLength (60, ErrorMessage = "NOme deve ter no máximo {1} caractere.")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Email é campo obrigatório")]
        [EmailAddress (ErrorMessage = "Email em formato inválido")]
        [StringLength (100, ErrorMessage = "Email deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}