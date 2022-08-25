using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWebApi.Model
{
	public class Category
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		public string Title { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}

