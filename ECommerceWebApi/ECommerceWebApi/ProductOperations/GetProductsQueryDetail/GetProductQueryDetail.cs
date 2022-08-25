using System;
using AutoMapper;
using ECommerceWebApi.DbOperations;
using ECommerceWebApi.Model;
using ECommerceWebApi.Commen;

namespace ECommerceWebApi.ProductOperations.GetProductsQueryDetail
{
	public class GetProductQueryDetail
	{
        private readonly ECommerceDbContext _dbContext;
        private readonly IMapper _mapper;

        public int ProductId { get; set; }

        public GetProductQueryDetail(ECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ProductDetailViewModel Handle()
        {
            var product = _dbContext.Products.Where(product => product.Id == ProductId).SingleOrDefault();
            if (product == null)
            {
                throw new InvalidOperationException("ürün bulunamadı");
            }
            ProductDetailViewModel vm = new ProductDetailViewModel();
            vm.Name = product.Name;
            vm.Price = product.Price;
            vm.PublishDate = product.PublishDate.ToString("dd/MM/yyyy");
            vm.CategoryId = product.Category.Title;
            return vm;
        }

    }
    public class ProductDetailViewModel
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public double Price { get; set; }
        public string PublishDate { get; set; }
    }

}

