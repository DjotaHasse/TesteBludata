using System;
using System.Collections.Generic;

namespace TesteBludata.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }
        public DateTime DataCadastro { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();

        public Fornecedor()
        { 
        }

        public Fornecedor(int id, string nome, string cPFCNPJ, DateTime dataCadastro, string rG, DateTime dataNascimento, Empresa empresa)
        {
            Id = id;
            Nome = nome;
            CPFCNPJ = cPFCNPJ;
            DataCadastro = dataCadastro;
            RG = rG;
            DataNascimento = dataNascimento;
            Empresa = empresa;
        }

        public void AddTelefone(Telefone telefone) 
        {
            Telefones.Add(telefone);    
        }

        public void RemoveTelefone(Telefone telefone) 
        {
            Telefones.Remove(telefone);
        }
    }
}
