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
                var metodoProduto = new ProdutoDAO();
                metodoProduto.Insert(produto);
                return RedirectToAction("ProdCadastrados");
            }
            return View(produto);
        }
        public ActionResult ProdCadastrados()
        {
            var metodoProduto = new ProdutoDAO();
            var todosProdutos = metodoProduto.Listar();
            return View(todosProdutos);
        }
        public ActionResult Editar(int id)
        {
            var metodoProduto = new ProdutoDAO();
            var produto = metodoProduto.ListarId(id);
            if(produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var metodoProduto = new ProdutoDAO();
                metodoProduto.Atualizar(produto);
                return RedirectToAction("ProdCadastrados");
            }
            return View(produto);
        }
        public ActionResult Detalhes(int id)
        {
            var metodoProduto = new ProdutoDAO();
            var produto = metodoProduto.ListarId(id);

            if(produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        public ActionResult Excluir(int id)
        {
            var metodoProduto = new ProdutoDAO();
            var produto = metodoProduto.ListarId(id);

            if(produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int id)
        {
            var metodoProduto = new ProdutoDAO();
            Produto produto = new Produto();
            produto.id_prod = id;
            metodoProduto.Excluir(produto);
            return RedirectToAction("ProdCadastrados");
        }
    }
}