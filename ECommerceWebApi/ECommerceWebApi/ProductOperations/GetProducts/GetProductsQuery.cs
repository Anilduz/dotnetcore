using System;
using AutoMapper;
using ECommerceWebApi.DbOperations;
using ECommerceWebApi.Model;
using ECommerceWebApi.Commen;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ECommerceWebApi.ProductOperations.GetProducts
{
	public class GetProductsQuery
	{
        private readonly ECommerceDbContext _dbContext;
        public GetProductsQuery(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductsViewModel> Handle()
        {
            var productList = _dbContext.Products.OrderBy(product => product.Id).ToList();
            List<ProductsViewModel> vm = new List<ProductsViewModel>();
            foreach (var product in productList)
            {
                vm.Add(new ProductsViewModel()
                {
                    Name = product.Name,
                    Price = product.Price,
                    PublishDate = product.PublishDate.ToString("dd/MM/yyyy"),
                    CategoryId = product.CategoryId
                });;
            }
            return vm;
        }

    }
    public class ProductsViewModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public string PublishDate { get; set; }
    }

}

