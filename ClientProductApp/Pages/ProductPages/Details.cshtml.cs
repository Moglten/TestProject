using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClientProductApp;
using ClientProductApp.InfrastructureLayer.Data.Contexts;
using ClientProductApp.DomainLayer.Interfaces;
using AutoMapper;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.DomainLayer.Entities;
using ProductProductApp.ApplicationLayer.Services;

namespace ClientProductApp.Pages.ProductPages
{
    public class DetailsModel : PageModel
    {
        private readonly ProductService _productService;

        public DetailsModel(IMapper mapper
                         , IGenericRepository<Product> genericRepository)
        {
            _productService = new ProductService(mapper, genericRepository);
        }

        public ProductViewModel Product { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            Product = _productService.GetProductById(id);

            return Product == null ? NotFound() : Page();
        }
    }
}
