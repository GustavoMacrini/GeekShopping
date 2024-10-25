﻿namespace GeekShopping.ProductAPI.Model.Product
{
    public record ProductRequest(Guid Id, string Name, decimal Price, string Description, string Category, string ImageUrl);
}
