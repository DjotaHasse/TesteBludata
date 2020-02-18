using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteBludata.Models;
using TesteBludata.Models.ViewModels;
using TesteBludata.Services;
using TesteBludata.Services.Exceptions;

namespace TesteBludata.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly FornecedorService _fornecedorService;
        private readonly EmpresaService _empresaService;

        public string RequestId { get; private set; }

        public FornecedoresController(FornecedorService fornecedorService, EmpresaService empresaService)
        {
            _fornecedorService = fornecedorService;
            _empresaService = empresaService;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _fornecedorService.FindAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            var empresas = await _empresaService.FindAllAsync();
            var viewModel = new FornecedorFormViewModel { Empresas = empresas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Contra ataques no ASP.NET
        public async Task<IActionResult> Create(Fornecedor fornecedor) 
        {
            if (!ModelState.IsValid)
            {
                //Para validar quando JS estiver desabilitado
                var empresas = await _empresaService.FindAllAsync();
                var viewModel = new FornecedorFormViewModel { Fornecedor = fornecedor, Empresas = empresas };
                return View(viewModel);
            }
            fornecedor.DataCadastro = DateTime.Now;
            await _fornecedorService.InsertAsync(fornecedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) 
        {
            if (id == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _fornecedorService.FindByIdAsync(id.Value);
            if (obj == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                await _fornecedorService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" }); 
            }

            var obj = await _fornecedorService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _fornecedorService.FindByIdAsync(id.Value);
            if (obj == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Empresa> empresas = await _empresaService.FindAllAsync();
            FornecedorFormViewModel viewModel = new FornecedorFormViewModel { Fornecedor = obj, Empresas = empresas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fornecedor fornecedor) 
        { 
            if (!ModelState.IsValid)
            {
                //Para validar quando JS estiver desabilitado
                var empresas = await _empresaService.FindAllAsync();
                var viewModel = new FornecedorFormViewModel { Fornecedor = fornecedor, Empresas = empresas };
                return View(viewModel);
            }

            if (id != fornecedor.Id) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id diferente" });
            }  

            try
            {
                await _fornecedorService.UpdateAsync(fornecedor);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public IActionResult Error(string message) 
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

        public async Task<IActionResult> FilterSearch(string name, string cpfCnpj, DateTime? dataCadastro) 
        {
            return View(await _fornecedorService.FindByFilterAsync(name, cpfCnpj, dataCadastro));    
        }
    }
}