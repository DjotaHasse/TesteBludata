using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBludata.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string UF { get; set; }
    }
}
