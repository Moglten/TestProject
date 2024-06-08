using AutoMapper;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.ApplicationLayer.Models.UIComponants;
using ClientProductApp.ApplicationLayer.Models.ViewModels;
using ClientProductApp.ApplicationLayer.Services;
using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.DomainLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductProductApp.ApplicationLayer.Services;

namespace ClientProductApp.Pages.ClientPages
{
    public class AttachProductModel : PageModel
    {
        private readonly ClientProductsService _clientProductService;

        public AttachProductModel(IMapper mapper
                         , IGenericRepository<ClientProducts> ClientProductsRepository
                         , IGenericRepository<Client> ClientRepository
                         , IGenericRepository<Product> ProductRepository)
        {
            _clientProductService = new ClientProductsService(mapper, ClientProductsRepository, ClientRepository, ProductRepository);
        }

        [BindProperty]
        public ClientProductViewModel ClientProducts { get; set; }

        public void OnGetAsync(int id)
        {
            ClientProducts = _clientProductService.GetClientProductViewModel(id);
            return;
        }

        public IActionResult OnPostAsync()
        {
            var clientProduct = _clientProductService.GetClientProductsById(ClientProducts.ClientId);

            _clientProductService.UpdateClientProducts(ClientProducts);

            return RedirectToPage("./Index");
        }
    }
}
