using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Hosting;

namespace ECommerceWebApi.Model
{
	public class Basket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BasketId { get; set; }
        public ICollection<Product> ProductsInBasket { get; set; }
    }
}

