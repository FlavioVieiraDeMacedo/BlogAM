﻿using BlogAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogAM.Controllers
{
    public class ProdutoController : Controller
    {
        #region Listar
        [Authorize]
        [HttpGet]
        public ActionResult Index(string NomePesquisa="")
        {
            List<Produto> produtos = new List<Produto>();
            if (NomePesquisa=="")
            {
            produtos = DAO.ProdutoDAO.listar();
            return View(produtos);
            }
            else
            {
                produtos = DAO.ProdutoDAO.pesquisar(NomePesquisa);
                return View(produtos);
            }
        }
        #endregion

        #region Cadastrar
        [Authorize]
        [HttpPost]
        public ActionResult Index(Produto produto)
        {
            DAO.ProdutoDAO.cadastrar(produto);
            return RedirectToAction("Index");
        }
        #endregion

        #region Deletar Noticia
        [Authorize]
        [HttpPost]
        public ActionResult Deletar(int tbxId)
        {
            DAO.ProdutoDAO.deletar(tbxId);
            return RedirectToAction("Index");
        }
        #endregion

        #region Editar Noticia
        [Authorize]
        [HttpPost]
        public ActionResult Editar(Produto produto)
        {

            DAO.ProdutoDAO.editar(produto.Id,produto);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Editar(int Id)
        {
            Produto produto = DAO.ProdutoDAO.pesquisar(Id);
            return View(produto);
        }
        #endregion

        #region pesquisar
        [Authorize]
        [HttpGet]
        public ActionResult Pesquisar(string NomePesquisa)
        {
            return RedirectToAction("Index","Produto",NomePesquisa);
        }
        #endregion

        }
}