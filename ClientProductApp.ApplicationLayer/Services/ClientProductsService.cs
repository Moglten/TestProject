using AutoMapper;
using ClientProductApp.ApplicationLayer.Models.UIComponants;
using ClientProductApp.ApplicationLayer.Models.ViewModels;
using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.DomainLayer.Interfaces;
using ProductProductApp.ApplicationLayer.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProductApp.ApplicationLayer.Services
{
    public class ClientProductsService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ClientProducts> _clientProductsRepository;
        private readonly ClientService _clientService;
        private readonly ProductService _productService;

        public ClientProductsService(IMapper mapper
                                    , IGenericRepository<ClientProducts> clientProductsRepository
                                    , IGenericRepository<Client> clientRepository
                                    , IGenericRepository<Product> productRepository )
        {
            _mapper = mapper;
            _clientProductsRepository = clientProductsRepository;
            _clientService = new ClientService(mapper, clientRepository);
            _productService = new ProductService(mapper, productRepository);
        }

        public List<ClientProducts> GetClientProductsById(int clientId)
        {
            return _clientProductsRepository.GetEntityIQueryable().Where(x => x.ClientId == clientId).ToList();
        }
         
        public ClientProductViewModel GetClientProductViewModel(int clientId)
        {
            var ClientProducts = new ClientProductViewModel();

            // Get Client With Attached Products
            var products = _productService.GetActivatedProducts();
            var ClientWithProduct = _clientService.GetClientWithAttachedProduct(clientId);

            ClientProducts.ClientId = ClientWithProduct.Id;
            ClientProducts.ClientName = ClientWithProduct.Name;
            ClientProducts.Code = ClientWithProduct.Code;

            foreach (var product in products)
            {
                ClientProducts.ProductsCheckBoxes.Add(
                    new CheckBoxViewModel
                    {
                        Text = product.Name,
                        Id = product.Id,
                        IsChecked = ClientWithProduct.AttachedProducts.Any(x => x.Id == product.Id)
                    });
            }

            return ClientProducts;
        }

        public void UpdateClientProducts(ClientProductViewModel clientProducts)
        {
            var clientProductsToDelete = _clientProductsRepository.GetEntityIQueryable().Where(x => x.ClientId == clientProducts.ClientId).ToList();
            var clientProductToAdd = new List<ClientProducts>();

            clientProducts.ProductsCheckBoxes.ForEach(p =>
            {
                if (p.IsChecked)
                {
                    clientProductToAdd.Add(new ClientProducts()
                    {
                        ClientId = clientProducts.ClientId,
                        ProductId = p.Id,
                        StartDate = DateTime.Now,
                        License = Guid.NewGuid().ToString()
                    });
                }
            });

            _clientProductsRepository.DeleteRange(clientProductsToDelete);
            _clientProductsRepository.InsertRange(clientProductToAdd);
        }
    }
}
