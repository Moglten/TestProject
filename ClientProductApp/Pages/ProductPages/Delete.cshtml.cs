using AutoMapper;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.DomainLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductProductApp.ApplicationLayer.Services;

namespace ClientProductApp.Pages.ProductPages
{
    public class DeleteModel : PageModel
    {
        private readonly ProductService _ProductService;

        public DeleteModel(IMapper mapper
                         , IGenericRepository<Product> genericRepository)
        {
            _ProductService = new ProductService(mapper, genericRepository);
        }

        [BindProperty]
        public ProductViewModel Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _ProductService.GetProductById(id);

            if (Product == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var Product = _ProductService.GetProductById(id) ?? null;

            if (Product == null) return NotFound();

            _ProductService.DeleteProduct(Product);

            return RedirectToPage("./Index");
        }
    }
}
