
using AutoMapper;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.DomainLayer.Interfaces;

namespace ProductProductApp.ApplicationLayer.Services
{
    public class ProductService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _genericRepository;

        public ProductService(IMapper mapper, IGenericRepository<Product> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }


        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products = _genericRepository.GetAll();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
        }

        public void CreateNewProduct(ProductViewModel ProductViewModel)
        {
            var productToAdd = _mapper.Map<ProductViewModel, Product>(ProductViewModel);
            _genericRepository.Insert(productToAdd);
        }

        public void UpdateProduct(ProductViewModel ProductViewModel)
        {
            var productToUpdate = _mapper.Map<ProductViewModel, Product>(ProductViewModel);
            _genericRepository.Update(productToUpdate);
        }

        public void DeleteProduct(ProductViewModel ProductViewModel)
        {
            var productToDelete = _mapper.Map<ProductViewModel, Product>(ProductViewModel);
            _genericRepository.Delete(productToDelete);
        }

        public ProductViewModel GetProductById(int id)
        {
            var product = _genericRepository.Get(id);
            return _mapper.Map<Product, ProductViewModel>(product);
        }

        public IEnumerable<ProductViewModel> GetActivatedProducts()
        {
            var products = _genericRepository.GetEntityIQueryable().Where(elem => elem.IsActive).ToList();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
        }

    }
}
