using AutoMapper;
using GeekShopping.ProductAPI.Infra.Data;
using GeekShopping.ProductAPI.Model.Product;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductResponse> Create(ProductRequest request)
        {
            Product product = _mapper.Map<Product>(request);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<IEnumerable<ProductResponse>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductResponse>>(products);
        }

        public async Task<ProductResponse> FindById(Guid id)
        {
            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

            if(product == null)
            {
                throw new Exception("Product Not Found");
            }

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> Update(ProductRequest request)
        {
            Product product = await _context.Products.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

            if(product == null)
            {
                throw new Exception("Product Not Found");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Category = request.Category;
            product.ImageUrl = request.ImageUrl;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(product);
        }


        public async Task<Guid> Delete(Guid id)
        {

            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

            if(product == null)
            {
                throw new Exception("Product Not Found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
        
    }
}
