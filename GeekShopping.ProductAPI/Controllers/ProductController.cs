using GeekShopping.ProductAPI.Infra.Repositories;
using GeekShopping.ProductAPI.Model.Product;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IResult> FindAll()
        {
            var response = await _repository.FindAll();
            return Results.Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IResult> FindById(Guid id)
        {
            try
            {
                var response = await _repository.FindById(id);

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IResult> Create([FromBody] ProductRequest request)
        {
            try
            {
                var response = await _repository.Create(request);

                return Results.Ok(response);
            }
            catch(Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IResult> Update([FromBody] ProductRequest request)
        {
            try
            {
                var response = await _repository.Update(request);

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IResult> Delete(Guid id)
        {
            try
            {
                var result = await _repository.Delete(id);
                return Results.Ok($"Product {result} has been Deleted");
            }
            catch(Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        }
    }
}
