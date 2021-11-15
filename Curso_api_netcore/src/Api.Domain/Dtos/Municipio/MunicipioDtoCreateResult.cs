using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.Municipio
{
    public class MunicipioDtoCreateResult 
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int CodIBGE { get; set; }

        public Guid UfId { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
