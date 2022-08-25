using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWebApi.Model
{
	public class Product
	{ 

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
        public double Price { get; set; }
        public DateTime PublishDate { get; set; }



        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}

