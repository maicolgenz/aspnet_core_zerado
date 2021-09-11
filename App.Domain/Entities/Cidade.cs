using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class Cidade
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
    }
}
