﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteBludata.Extensions;

namespace TesteBludata.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} requerido")]
        public string Nome { get; set; }
        [Display(Name = "CPF/CNPJ")]
        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "{0} deve conter no mínimo {2} e no máximo {1} números")]
        private string cpfcnpj;
        public string CPFCNPJ { get; set; }
        [Display(Name = "Data Cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }
        public string RG { get; set; }
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
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
