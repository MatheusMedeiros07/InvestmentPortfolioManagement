using AutoMapper;
using InvestmentPortfolioManagement.Entities;
using InvestmentPortfolioManagement.Dtos;


namespace InvestmentPortfolioManagement.Mappings
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())  // Ignora inicialmente
            .AfterMap((src, dest, context) =>
            {
                // Contexto usado para passar o Id como parâmetro
                var passedId = (int)context.Items["Id"];
                dest.Id = passedId;
            });

            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Investment, InvestmentDto>().ReverseMap();
        }
    }
}
