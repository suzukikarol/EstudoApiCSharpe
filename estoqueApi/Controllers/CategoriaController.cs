using Dapper;
using SistemaEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace estoqueApi.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<Categoria>("VerTodasCategorias")); 
        }

        [HttpGet]
        public ActionResult AddOuEdiTCaT(int Id = 0)
        {
            if (Id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@IdCategoria", Id);
                return View(DapperORM.ReturnList<Categoria>("VerCategoriaPorId", param).FirstOrDefault<Categoria>());

            }
        }

        [HttpPost]
        public ActionResult AddOuEdiTCaT(Categoria categoria)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@IdCategoria", categoria.IdCategoria);
            param.Add("@TipoCategoria", categoria.TipoCategoria);
            DapperORM.ExecuteWithoutReturn("AddOuEdiTCaT", param);
            return RedirectToAction("Index");
        }

        public ActionResult DeletarCategoria(int Id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@IdCategoria", Id);
            DapperORM.ExecuteWithoutReturn("DeletarCategoria", param);
            return RedirectToAction("Index");

        }
    }
}