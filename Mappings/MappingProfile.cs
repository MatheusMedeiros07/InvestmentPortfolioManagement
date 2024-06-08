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
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Investment, InvestmentDto>().ReverseMap();
        }
    }
}
