using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteBludata.Extensions;

namespace TesteBludata.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} requerido")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ deve conter 14 números")]
        private string cnpj;
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "{0} requerido")]
        public string UF { get; set; }
        public ICollection<Fornecedor> Fornecedores { get; set; } = new List<Fornecedor>();

        public Empresa()
        {
        }

        public Empresa(int id, string razaoSocial, string cNPJ, string uF)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            CNPJ = cNPJ;
            UF = uF;
        }

        public void AddFornecedor(Fornecedor fornecedor) 
        {
            Fornecedores.Add(fornecedor);
        }

        public void RemoveFornecedor(Fornecedor fornecedor)
        {
            Fornecedores.Remove(fornecedor);
        }
    }
}
