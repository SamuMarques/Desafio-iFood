using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio.iFood.API.Domain;
using Desafio.iFood.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.iFood.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] IProductRepository productRepository)
        {
            return await productRepository.Get();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> Get([FromServices] IProductRepository productRepository, int id)
        {
            return await productRepository.GetById(id);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromServices] IProductRepository productRepository, [FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(await productRepository.Create(product));
                }
                catch (System.Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Product>> Put([FromServices] IProductRepository productRepository, [FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return await productRepository.Update(product);
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete([FromServices] IProductRepository productRepository, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productRepository.Delete(id);
                    return Ok();
                }
                catch (System.Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
