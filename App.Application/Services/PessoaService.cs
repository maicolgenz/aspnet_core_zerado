using App.Common;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private IRepositoryBase<Pessoa> _repository { get; set; }
        public PessoaService(IRepositoryBase<Pessoa> repository)
        {
            _repository = repository;
        }
        public Pessoa BuscaPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o id");
            }
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Pessoa> listaPessoas(string nome, int pesoMaiorQue, int pesoMenorQue)
        {

            nome = nome ?? "";
            return _repository.Query(x =>
            x.Nome.ToUpper().Contains(nome.ToUpper()) &&
            (pesoMaiorQue == 0 || x.Peso >= pesoMaiorQue) &&
            (pesoMenorQue == 0 || x.Peso <= pesoMenorQue)
            ).Select(p => new Pessoa
            {
                Id = p.Id,
                Nome = p.Nome,
                Peso = p.Peso,
                Cidade = new Cidade
                {
                    Nome = p.Cidade.Nome
                },
                Ativo = p.Ativo,
                DataNascimento = p.DataNascimento,
                telefone = p.telefone,
                cpf =TextoHelper.CpfCnpjFormatado(p.cpf)
            }).OrderByDescending(x => x.Nome).ToList();
        }
        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public void Salvar(Pessoa obj)
        {
            if (String.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("Informe o nome");
            }
            if (!obj.cpf.CpfCnpjValido())
            {
                throw new Exception("Cpf inválido");
            }
            if(obj.Id == Guid.Empty)/*Se for alteração*/
            {
                bool existe = _repository.Query(x => x.cpf == obj.cpf).Any();
                if (existe)
                {
                    throw new Exception("CPF existente na base de dados");
                }
            }
            _repository.Save(obj);
            _repository.SaveChanges();
        }
    }
}
