using App.Domain.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Interfaces.Application
{
    public interface IPessoaService
    {
        Pessoa BuscaPorId(Guid id);
        List<Pessoa> listaPessoas();
        void Salvar(Pessoa obj);
    }
}
