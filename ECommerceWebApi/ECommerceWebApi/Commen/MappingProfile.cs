using System;
using AutoMapper;
using ECommerceWebApi.Model;
using ECommerceWebApi.ProductOperations.GetProductsQueryDetail;
using static ECommerceWebApi.ProductOperations.CreateProduct.CreateProductCommand;
namespace ECommerceWebApi.Commen

{
	public class MappingProfile : Profile
	{
       public MappingProfile()
		{
            //CreateMap<CreateProductModel, Product>();
            //CreateMap<Product, ProductDetailViewModel>().ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => ((Category)src.Name).ToString()));

        }
    }
}

