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
        public IActionResult Index()
        {
            var list = _fornecedorService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var empresas = _empresaService.FindAll();
            var viewModel = new FornecedorFormViewModel { Empresas = empresas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Contra ataques no ASP.NET
        public IActionResult Create(Fornecedor fornecedor) 
        {
            if (!ModelState.IsValid)
            {
                //Para validar quando JS estiver desabilitado
                var empresas = _empresaService.FindAll();
                var viewModel = new FornecedorFormViewModel { Fornecedor = fornecedor, Empresas = empresas };
                return View(viewModel);
            }
            _fornecedorService.Insert(fornecedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _fornecedorService.FindById(id.Value);
            if (obj == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
            _fornecedorService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) 
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" }); 
            }

            var obj = _fornecedorService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id) 
        {
            if (id == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _fornecedorService.FindById(id.Value);
            if (obj == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Empresa> empresas = _empresaService.FindAll();
            FornecedorFormViewModel viewModel = new FornecedorFormViewModel { Fornecedor = obj, Empresas = empresas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Fornecedor fornecedor) 
        { 
            if (!ModelState.IsValid)
            {
                //Para validar quando JS estiver desabilitado
                var empresas = _empresaService.FindAll();
                var viewModel = new FornecedorFormViewModel { Fornecedor = fornecedor, Empresas = empresas };
                return View(viewModel);
            }

            if (id != fornecedor.Id) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id diferente" });
            }  

            try
            {
                _fornecedorService.Update(fornecedor);
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
    }
}