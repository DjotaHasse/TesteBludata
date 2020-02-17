using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteBludata.Models;
using TesteBludata.Models.ViewModels;
using TesteBludata.Services;

namespace TesteBludata.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly FornecedorService _fornecedorService;
        private readonly EmpresaService _empresaService;

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
            _fornecedorService.Insert(fornecedor);
            return RedirectToAction(nameof(Index));
        }
    }
}