using Dapper;
using SistemaEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace estoqueApi.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        [HttpGet]
        public ActionResult Index()
        {
            //var aux = new SelectList(DapperORM.ReturnList<Categoria>("VerTodasCategorias"), "IdCategoria", "TipoCategoria");
            //ViewData["p"]: aux();

            var categoria = new SelectList(DapperORM.ReturnList<Categoria>("VerTodasCategorias"),"");
            ViewBag.DropDownValues = new SelectList(new[] { "IdCategoria" });
            ViewData["Categoria"] = categoria;
            return View(DapperORM.ReturnList<Produto>("VerTodosProdutos"));           
        }

        [HttpGet]
        public ActionResult AdicionarOuEditar(int Id = 0)
        {
            if (Id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@IdProduto", Id);
                return View(DapperORM.ReturnList<Produto>("VerProdutoPorId", param).FirstOrDefault<Produto>());

            }
        }

        [HttpPost]
        public ActionResult AdicionarOuEditar(Produto produto)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@IdProduto", produto.IdProduto);
            param.Add("@Nome", produto.Nome);
            param.Add("@IdCategoria", produto.Categoria);
            param.Add("@Quantidade", produto.Quantidade);
            DapperORM.ExecuteWithoutReturn("AdicionarOuEditar", param);
            return RedirectToAction("Index");
        }

        public ActionResult DeletarProduto(int Id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@IdProduto", Id);
            DapperORM.ExecuteWithoutReturn("DeletarProduto", param);
            return RedirectToAction("Index");

        }

        public ActionResult VerTodosProdutos(int Id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@IdProduto", Id);
            return View(DapperORM.ReturnList<Produto>("VerTodosProdutos"));
        }
    }
}