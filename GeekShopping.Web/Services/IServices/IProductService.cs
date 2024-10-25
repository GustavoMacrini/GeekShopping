using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();
        Task<ProductModel> FindProductById(Guid id);
        Task<ProductModel> CreateProduct(ProductModel model);

        Task<ProductModel> UpdateProduct(ProductModel model);

        Task<Guid> DeleteProductById(Guid id);
    }
}
