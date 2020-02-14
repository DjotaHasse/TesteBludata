using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteBludata.Services;

namespace TesteBludata.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly FornecedorService _fornecedorService;

        public FornecedoresController(FornecedorService fornecedorService) 
        {
            _fornecedorService = fornecedorService;
        }
        public IActionResult Index()
        {
            var list = _fornecedorService.FindAll();               

            return View(list);
        }
    }
}