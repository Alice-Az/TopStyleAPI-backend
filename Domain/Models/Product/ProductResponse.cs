﻿namespace TopStyleAPI.Domain.Models.Product
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductImage { get; set; }
    }
}
