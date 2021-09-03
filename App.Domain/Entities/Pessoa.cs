using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class Pessoa
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Peso { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
    }
}
