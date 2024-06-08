using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using ClientProductApp.DomainLayer.Interfaces;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.ApplicationLayer.Services;
using ClientProductApp.DomainLayer.Entities;

namespace ClientProductApp.Pages.ClientPages
{
    public class DeleteModel : PageModel
    {
        private readonly ClientService _clientService;

        public DeleteModel( IMapper mapper
                         , IGenericRepository<Client> genericRepository)
        {
            _clientService = new ClientService(mapper, genericRepository);
        }


        [BindProperty]
        public ClientViewModel Client { get; set; } = default!;


        public IActionResult OnGet(int id)
        {
            Client = _clientService.GetClientById(id);

            return Client == null ? NotFound() : Page();
        }

        public IActionResult OnPost(int id)
        {
            var client = _clientService.GetClientById(id);

            if (client == null) return NotFound();

            _clientService.DeleteClient(client);

            return RedirectToPage("./Index");
        }
    }
}
