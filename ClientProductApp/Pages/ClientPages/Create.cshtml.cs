using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClientProductApp.DomainLayer.Enums;
using ClientProductApp.ViewHelper;
using ClientProductApp.InfrastructureLayer.Data.Contexts;
using AutoMapper;
using ClientProductApp.DomainLayer.Interfaces;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.ApplicationLayer.Services;

namespace ClientProductApp.Pages.ClientPages
{
    public class CreateModel : PageModel
    {
        private readonly ClientService _clientService;

        public CreateModel(IMapper mapper
                         , IGenericRepository<Client> genericRepository)
        {
            _clientService = new ClientService(mapper, genericRepository);
        }

        public SelectList ClassList { get; set; }
        public SelectList ClassState { get; set; }

        [BindProperty]
        public ClientViewModel InputedClient { get; set; }

        public IActionResult OnGet()
        {
            DropDownHandlers();
            return Page();
        }



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                DropDownHandlers();
                return Page();
            }

            _clientService.CreateNewClient(InputedClient);

            return RedirectToPage("./Index");
        }

        private void DropDownHandlers()
        {
            ClassList = DropDownsHandler.GetSelectList<ClassName>();
            ClassState = DropDownsHandler.GetSelectList<ClassState>();
        }
    }
}
