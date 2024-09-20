using GeekShopping.ProductAPI.Model.Product;

namespace GeekShopping.ProductAPI.Infra.Repositories
{
    public interface IProductRepository
    {
        Task<ProductResponse> Create(ProductRequest request);
        Task<IEnumerable<ProductResponse>> FindAll();
        Task<ProductResponse> FindById(Guid id);        
        Task<ProductResponse> Update(Guid id,ProductRequest request);
        Task<Guid> Delete(Guid id);

    }
}
