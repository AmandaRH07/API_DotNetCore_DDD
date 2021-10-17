using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Cep
{
    public class CepDtoUpdate
    {
        [Required(ErrorMessage = "Id  é campo Obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "CEP é campo Obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Logradouro é campo Obrigatório")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        [Required(ErrorMessage = "Municipio é campo Obrigatório")]
        public Guid MunicipioId { get; set; }
    }
}
