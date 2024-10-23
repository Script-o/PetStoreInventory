using System;

namespace Templates
{
	public class Product
	{
		public required string Name { get; set; }
		public required decimal Price { get; set; }
        public required int Quantity { get; set; }
        public required string Description { get; set; }
    }
}