using System;
using System.Collections.Generic;
using System.Linq;
using ControleDeContatos.Data;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(b => b.Id == id);
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);
            if (contatoDB == null) throw new Exception("Houve um erro na atualização");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;
            
            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if(contatoDB == null) throw new Exception("Houve um erro");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges() ;
            return true;
        }
    }
}
