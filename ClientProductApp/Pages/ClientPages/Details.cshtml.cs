using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClientProductApp.DomainLayer.Interfaces;
using AutoMapper;
using ClientProductApp.ApplicationLayer.Services;
using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.Applicationlayer.Models.ViewModels;


namespace ClientProductApp.Pages.ClientPages
{
    public class DetailsModel : PageModel
    {
        private readonly ClientService _clientService;

        public DetailsModel(IMapper mapper
                         , IGenericRepository<Client> genericRepository)
        {
            _clientService = new ClientService(mapper, genericRepository);
        }

        [BindProperty]
        public ClientViewModel Client { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            Client = _clientService.GetClientWithAttachedProduct(id);

            return Client == null ? NotFound() : Page();
        }
    }
}
