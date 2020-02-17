using System.Collections.Generic;

namespace TesteBludata.Models.ViewModels
{
    public class FornecedorFormViewModel
    {
        public Fornecedor Fornecedor { get; set; }
        public ICollection<Empresa> Empresas { get; set; }
    }
}
