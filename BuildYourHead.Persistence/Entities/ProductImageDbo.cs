﻿namespace BuildYourHead.Persistence.Entities
{
    public class ProductImageDbo
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; } = null!;

        public ProductDbo Product { get; set; } = null!;
    }
}
