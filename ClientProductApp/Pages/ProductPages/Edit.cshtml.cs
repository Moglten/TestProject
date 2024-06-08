using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClientProductApp.InfrastructureLayer.Data.Contexts;
using AutoMapper;
using ClientProductApp.DomainLayer.Interfaces;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.DomainLayer.Entities;
using ProductProductApp.ApplicationLayer.Services;


namespace ClientProductApp.Pages.ProductPages
{
    public class EditModel : PageModel
    {
        private readonly ProductService _productService;

        public EditModel(IMapper mapper
                         , IGenericRepository<Product> genericRepository)
        {
            _productService = new ProductService(mapper, genericRepository);
        }


        [BindProperty]
        public ProductViewModel Product { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            Product = _productService.GetProductById(id) ?? null;

            return Product == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                _productService.UpdateProduct(Product);
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToPage("./Error");
            }

            return RedirectToPage("./Index");
        }
    }
}
