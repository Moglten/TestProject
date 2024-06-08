using AutoMapper;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace ClientProductApp.ApplicationLayer.Services
{
    public class ClientService
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepository<Client> _genericRepository;

        public ClientService(IMapper mapper, IGenericRepository<Client> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public IEnumerable<ClientViewModel> GetAllClients()
        {
            var clients = _genericRepository.GetAll();
            return _mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(clients);
        }

        public void CreateNewClient(ClientViewModel clientViewModel)
        {
            var clientToAdd = _mapper.Map<ClientViewModel, Client>(clientViewModel);
            _genericRepository.Insert(clientToAdd);
        }

        public void UpdateClient(ClientViewModel clientViewModel)
        {
            var clientToUpdate = _mapper.Map<ClientViewModel, Client>(clientViewModel);
            _genericRepository.Update(clientToUpdate);
        }

        public void DeleteClient(ClientViewModel clientViewModel)
        {
            var clientToDelete = _mapper.Map<ClientViewModel, Client>(clientViewModel);
            _genericRepository.Delete(clientToDelete);
        }

        public ClientViewModel GetClientById(int id)
        {
            var client = _genericRepository.Get(id);
            return _mapper.Map<Client, ClientViewModel>(client);
        }

        public ClientViewModel GetClientWithAttachedProduct(int id)
        {
            var client = _genericRepository.GetDbSet()
                                     .Where(c => c.Id == id)
                                     .Include(x => x.ClientProducts)
                                     .ThenInclude(x => x.Product)
                                     .FirstOrDefault()!;

            return _mapper.Map<Client, ClientViewModel>(client);
        }
    }
}
