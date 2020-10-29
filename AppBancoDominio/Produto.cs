using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppBancoDominio
{
    public class Produto
    {
        [DisplayName("ID do Produto:")]
        public int id_prod { get; set; }
        [DisplayName("Nome do Produto:")]
        public string nm_prod { get; set; }
        [DisplayName("Categoria do Produto:")]
        public string cat_prod { get; set; }
        [DisplayName("Data de cadastro do Produto:")]
        [Required(ErrorMessage = "Digite a data de cadastro do produto!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime data_prod { get; set; }
    }
}
