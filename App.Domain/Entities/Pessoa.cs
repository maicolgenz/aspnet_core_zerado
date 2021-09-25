using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Guid? CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
    }
}
