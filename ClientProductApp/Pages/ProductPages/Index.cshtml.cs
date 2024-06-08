using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClientProductApp;
using ClientProductApp.InfrastructureLayer.Data.Contexts;
using AutoMapper;
using ClientProductApp.DomainLayer.Interfaces;
using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.ApplicationLayer.Services;
using ProductProductApp.ApplicationLayer.Services;

namespace ClientProductApp.Pages.ProductPages
{
    public class IndexModel : PageModel
    {
        private readonly ProductService _productService;

        public IndexModel(IMapper mapper
                         , IGenericRepository<Product> genericRepository)
        {
            _productService = new ProductService(mapper, genericRepository);
        }
        public IList<ProductViewModel> ProductList { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProductList = _productService.GetAllProducts().ToList();
        }
    }
}
