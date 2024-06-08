using AutoMapper;
using ClientProductApp.Applicationlayer.Models.ViewModels;
using ClientProductApp.ApplicationLayer.Models.ViewModels;
using ClientProductApp.DomainLayer.Entities;
using ClientProductApp.DomainLayer.Enums;


namespace ClientProductApp.Applicationlayer.MapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapping Objects <source, destination>
            CreateMap<Client, ClientViewModel>()
               .ForMember(dist => dist.CName, opt => opt.MapFrom(src => Enum.GetValues(typeof(ClassName)).GetValue(src.Class)!.ToString()))
               .ForMember(dist => dist.SName, opt => opt.MapFrom(src => Enum.GetValues(typeof(ClassState)).GetValue(src.State)!.ToString()))
               .AfterMap((src, dist) => {
                   if (src.ClientProducts.Count > 0)
                       {
                            dist.AttachedProducts = src.ClientProducts.Select(x => x.Product).ToList();
                       }
               });

            CreateMap<ClientViewModel, Client>();

            ////----------------------------------------------------------------------
            ////Mapping Objects <source, destination>

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();


            ////----------------------------------------------------------------------
            ////Mapping Objects <source, destination>
            //_mapper.Map<ClientProducts, ClientProductViewModel>

            //CreateMap<ClientProductViewModel, ClientProducts>()
            //    .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
            //    .AfterMap((src, dist) =>
            //    {
            //        if (src.ProductsCheckBoxes.Count > 0)
            //        {
            //            // i will pop item from it and push to the product id
            //            dist.ProductId = src.ProductsCheckBoxes[0].Id;
            //            src.ProductsCheckBoxes.RemoveAt(0);
            //        }
            //    });


        }
     
    }
}
