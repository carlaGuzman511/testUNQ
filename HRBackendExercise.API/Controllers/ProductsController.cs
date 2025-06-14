using HRBackendExercise.API.Abstractions;
using HRBackendExercise.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRBackendExercise.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		// DO NOT MODIFY THE SIGNATURES, JUST THE BODIES
		private IProductsService productsService;
        public ProductsController(IProductsService productsService)
		{
		    this.productsService = productsService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
		{
			try
			{
                Product? product = this.productsService.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        IEnumerable<Product> products = this.productsService.GetAll();

        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        //    }
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
		{
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }

                if (product.Price <= 0)
                {
                    return BadRequest();
                }

                if (product.SKU == null)
                {
                    return BadRequest();
                }

                Product p = this.productsService.Create(product);

                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
		public IActionResult Put(Product product)
		{
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }

                if (product.Price <= 0)
                {
                    return BadRequest();
                }

                if (product.SKU == null)
                {
                    return BadRequest();
                }

                if (product.Id <= 0)
                {
                    return BadRequest();
                }

                Product? p = this.productsService.GetById(product.Id);

                if (p == null) 
                {
                    return NotFound();
                }
                else
                {
                    this.productsService.Update(product);
                    return NoContent();

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete]
		public IActionResult Delete(int id)
		{
            try
            {
                Product? product = this.productsService.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }

                this.productsService.Delete(product);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
	}
}
