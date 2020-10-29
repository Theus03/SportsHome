using AppBancoADO;
using AppBancoDominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDLL
{
    public class ProdutoDAO
    {
        private Banco db;
        public void Insert(Produto produto)
        {
            string strQuery = string.Format("Insert into tbl_usuario(nm_prod, cat_prod, data_prod)" +
                    "values('{0}', '{1}','{2}');", produto.nm_prod, produto.cat_prod, produto.data_prod.ToString("yyyy-MM-dd"));
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Atualizar(Produto produto)
        {
            var stratualiza = "";
            stratualiza += "update tbl_produto set ";
            stratualiza += string.Format(" nm_prod = '{0}', ", produto.nm_prod);
            stratualiza += string.Format(" cat_prod = '{0}', ", produto.cat_prod);
            stratualiza += string.Format(" data_prod = '{0}' ", produto.data_prod.ToString("yyyy-MM-dd"));
            stratualiza += string.Format(" Where id_prod = {0};", produto.id_prod);

            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Excluir(Produto produto)
        {
            var stratualiza = "";
            stratualiza += "delete from tbl_produto";
            stratualiza += string.Format(" Where id_prod = {0};", produto.id_prod);
            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Salvar(Produto produto)
        {
            if (produto.id_prod > 0)
            {
                Atualizar(produto);
            }
            else
            {
                Insert(produto);
            }
        }
        public List<Produto> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_produto";
            var retorno = db.retornaComando(strQuery);
            return listaProduto(retorno);
        }

        private List<Produto> listaProduto(MySqlDataReader retorno)
        {
            throw new NotImplementedException();
        }

        public Produto ListarId(int id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_produto where id_prod = {0} ", id);
                var retorno = db.retornaComando(strQuery);
                return listaProduto(retorno).FirstOrDefault();
            }
        }
        private List<Produto> listaProdutp(MySqlDataReader retorno)
        {
            var produtos = new List<Produto>();
            while (retorno.Read())
            {
                var TempProduto = new Produto()
                {
                    id_prod = int.Parse(retorno["id_prod"].ToString()),
                    nm_prod = retorno["nm_prod"].ToString(),
                    cat_prod = retorno["cat_prod"].ToString(),
                    data_prod = DateTime.Parse(retorno["data_prod"].ToString()),
                };
                produtos.Add(TempProduto);
            }
            return produtos;
        }
    }
}