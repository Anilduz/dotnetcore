using System;
using AutoMapper;
using ECommerceWebApi.DbOperations;
using ECommerceWebApi.Model;

namespace ECommerceWebApi.ProductOperations.CreateProduct
{
	public class CreateProductCommand
	{
        public CreateProductModel Model { get; set; }
        private readonly ECommerceDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateProductCommand(ECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var product = _dbContext.Products.SingleOrDefault(x => x.Name == Model.Name);
            if (product != null)
                throw new InvalidOperationException("Ürün zaten mevcut");

            product = _mapper.Map<Product>(Model); 


            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }
        public class CreateProductModel
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public double Price { get; set; }
            public string PublishDate { get; set; }
        }
    }
}

