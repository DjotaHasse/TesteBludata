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

        public async Task<List<Fornecedor>> FindAllAsync()
        {
            return await _context.Fornecedor.ToListAsync();    
        }

        public async Task InsertAsync(Fornecedor obj) 
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Fornecedor> FindByIdAsync(int id) 
        {
            return  await _context.Fornecedor.Include(obj => obj.Empresa).FirstOrDefaultAsync(obj => obj.Id == id);    
        }

        public async Task RemoveAsync(int id) 
        {
            try
            {
                var obj = await _context.Fornecedor.FindAsync(id);
                _context.Fornecedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e) 
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Fornecedor obj)
        {
            bool hasAny = await _context.Fornecedor.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e) 
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<List<Fornecedor>> FindByFilterAsync(string name, string cpfcnpj, DateTime? dataCadastro) 
        { 
            var result = from obj in _context.Fornecedor select obj;
            if (!String.IsNullOrEmpty(name)) 
            {
                result = result.Where(x => x.Nome == name);   
            }
            if (!String.IsNullOrEmpty(cpfcnpj))
            {
                result = result.Where(x => x.CPFCNPJ == cpfcnpj);
            }
            if (dataCadastro.HasValue)
            {
                result = result.Where(x => x.DataCadastro == dataCadastro);
            }
            return await result.Include(x => x.Empresa).OrderByDescending(x => x.Nome).ToListAsync();
        }
    }
}
