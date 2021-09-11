using App.Domain.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Interfaces.Application
{
    public interface IPessoaService
    {
        Pessoa BuscaPorId(Guid id);
        List<Pessoa> listaPessoas(string nome, int pesoMaiorQue, int pesoMenorQue);
        void Salvar(Pessoa obj);
        void Remover(Guid id);

    }
}
