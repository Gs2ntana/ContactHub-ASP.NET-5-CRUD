using Microsoft.AspNetCore.Mvc;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível apagar o contato!";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível realizar essa ação, detalhe do erro:{e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar, detalhe do erro:{e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível editar o contato, detalhe do erro:{e.Message}";
                return RedirectToAction("Index");
            }
            
            
        }
    }
}
