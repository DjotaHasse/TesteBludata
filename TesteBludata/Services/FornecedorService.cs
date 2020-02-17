using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBludata.Data;
using TesteBludata.Models;
using Microsoft.EntityFrameworkCore;
using TesteBludata.Services.Exceptions;

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
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Fornecedor FindById(int id) 
        {
            return _context.Fornecedor.Include(obj => obj.Empresa).FirstOrDefault(obj => obj.Id == id);    
        }

        public void Remove(int id) 
        {
            var obj = _context.Fornecedor.Find(id);
            _context.Fornecedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Fornecedor obj)
        {
            if (!_context.Fornecedor.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e) 
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
