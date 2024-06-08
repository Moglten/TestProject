using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientProductApp;
using ClientProductApp.InfrastructureLayer.Data.Contexts;
using AutoMapper;
using ClientProductApp.DomainLayer.Interfaces;
using ClientProductApp.DomainLayer.Enums;
using ClientProductApp.ViewHelper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.ApplicationLayer.Services;
using ClientProductApp.DomainLayer.Entities;

namespace ClientProductApp.Pages.ClientPages
{
    public class EditModel : PageModel
    {
        private readonly ClientService _clientService;

        public EditModel( IMapper mapper
                         , IGenericRepository<Client> genericRepository)
        {
            _clientService = new ClientService(mapper, genericRepository);
        }


        [BindProperty]
        public ClientViewModel Client { get; set; } = default!;
        public SelectList ClassList { get; set; }
        public SelectList ClassState { get; set; }


        public IActionResult OnGet(int id)
        {
            DropDownHandlers();

            Client = _clientService.GetClientById(id) ?? null;

            return Client == null ? NotFound() : Page();

        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                DropDownHandlers();
                return Page();
            }

            try
            {
                _clientService.UpdateClient(Client);
            }
            catch
            {
                return RedirectToPage("./Error");
            }

            return RedirectToPage("./Index");
        
        }

        private void DropDownHandlers()
        {
            ClassList = DropDownsHandler.GetSelectList<ClassName>();
            ClassState = DropDownsHandler.GetSelectList<ClassState>();
        }

    }
}
