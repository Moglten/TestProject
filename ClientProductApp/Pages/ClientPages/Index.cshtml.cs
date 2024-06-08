using Microsoft.AspNetCore.Mvc.RazorPages;
using ClientProductApp.InfrastructureLayer.Data.Contexts;
using ClientProductApp.DomainLayer.Interfaces;
using AutoMapper;
using ClientProductApp.DomainLayer.Enums;
using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.ApplicationLayer.Services;

namespace ClientProductApp.Pages.ClientPages
{
    public class IndexModel : PageModel
    {
        private readonly ClientService _clientService;

        public IndexModel(IMapper mapper
                         , IGenericRepository<Client> genericRepository)
        {
            _clientService = new ClientService(mapper, genericRepository);
        }

        public IList<ClientViewModel> ClientList { get;set; } = default!;

        public async Task OnGetAsync()
        { 
            ClientList = _clientService.GetAllClients().ToList();
        }
    }
}
