using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBludata.Data;
using TesteBludata.Models;

namespace TesteBludata.Services
{
    public class EmpresaService
    {
        private readonly TesteBludataContext _context;

        public EmpresaService(TesteBludataContext context)
        {
            _context = context;
        }

        public List<Empresa> FindAll() 
        {
            return _context.Empresa.OrderBy(x => x.RazaoSocial).ToList();
        }
    }
}
