using Onboarding.Server.ApplicationTier.Dtos;
using Onboarding.Server.ApplicationTier.Interfaces;
using Onboarding.Server.ApplicationTier.Common;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Onboarding.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductMethods _productMethods;

        public ProductController(IProductMethods productMethods)
        {
            _productMethods = productMethods;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagedDtos<ProductDto>>>> GetProducts(int pageNumber, int pageSize)
        {
            try
            {
                var pagedResult = await _productMethods.GetAllProductsAsync(pageNumber, pageSize);
                if (pagedResult == null)
                {
                    return NotFound();
                }

                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            try
            {
                var productDto = await _productMethods.GetProductAsync(id);
                if (productDto == null)
                {
                    return NotFound();
                }
                return productDto;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post(ProductDto? productDto)
        {
            try
            {
                if (productDto == null)
                {
                    return BadRequest("Give proper values for Product");
                }

                productDto = await _productMethods.AddProductAsync(productDto);
                return Created("", productDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Put(int id, ProductDto? productDto)
        {
            try
            {
                if (productDto == null)
                {
                    return BadRequest("Provide some value for Product");
                }

                productDto = await _productMethods.UpdateProductAsync(id, productDto);
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductDto>> Patch(int id, [FromBody] JsonPatchDocument<ProductDto> patchDto)
        {
            try
            {
                if (patchDto == null)
                {
                    return BadRequest("No values were send to change");
                }

                var productDto = await _productMethods.GetProductAsync(id);

                if (productDto == null)
                {
                    return BadRequest($"Product with ID {id} was not found.");
                }

                patchDto.ApplyTo(productDto);

                productDto = await _productMethods.PatchProductDetails(id, productDto);

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                var status = await _productMethods.DeleteProductAsync(id);

                if (status == StatusEnum.NoContent)
                {
                    return $"Product with Id: {id} deleted successfully!!!";
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
