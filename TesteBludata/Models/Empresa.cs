using System.Collections.Generic;

namespace TesteBludata.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
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
