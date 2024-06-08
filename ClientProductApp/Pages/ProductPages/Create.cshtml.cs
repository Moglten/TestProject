using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClientProductApp;
using AutoMapper;
using ClientProductApp.DomainLayer.Interfaces;
using ClientProductApp.InfrastructureLayer.Data.Contexts;
using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.ApplicationLayer.Services;
using ProductProductApp.ApplicationLayer.Services;
using ClientProductApp.InfrastructureLayer.Repository;
using ClientProductApp.Applicationlayer.Models.ViewModels;

namespace ClientProductApp.Pages.ProductPages
{
    public class CreateModel : PageModel
    {
        private readonly ProductService _productService;

        public CreateModel(IMapper mapper
                         , IGenericRepository<Product> genericRepository)
        {
            _productService = new ProductService(mapper, genericRepository);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductViewModel Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productService.CreateNewProduct(Product);

            return RedirectToPage("./Index");
        }


    }
}
