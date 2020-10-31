using AppBancoDLL;
using AppBancoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsHome.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Produtos()
        {
            return View();
        }
        public ActionResult Cadastros()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastros(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var metodoUsuario = new ProdutoDAO();
                metodoUsuario.Insert(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }
        public ActionResult ProdCadastrados()
        {
            var metodoProduto = new ProdutoDAO();
            var todosProdutos = metodoProduto.Listar();
            return View(todosProdutos);
        }
    }
}