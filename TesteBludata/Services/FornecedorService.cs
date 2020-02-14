using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBludata.Data;
using TesteBludata.Models;

namespace TesteBludata.Services
{
    public class FornecedorService
    {
        private readonly TesteBludataContext _context;

        public FornecedorService(TesteBludataContext context) 
        {
            _context = context;
        }

        public List<Fornecedor> FindAll()
        {
            return _context.Fornecedor.ToList();    
        }

        public void Insert(Fornecedor obj) 
        {
            obj.Empresa = _context.Empresa.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
