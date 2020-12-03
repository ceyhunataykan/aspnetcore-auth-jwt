using System.Threading.Tasks;
using AutoMapper;
using CA.ProductCoreApp.Business.Interfaces;
using CA.ProductCoreApp.Business.StringInfos;
using CA.ProductCoreApp.Entities.Concrete;
using CA.ProductCoreApp.Entities.Dtos.ProductDtos;
using CA.ProductCoreApp.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CA.ProductCoreApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = RoleInfo.Admin + "," + RoleInfo.Member)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = RoleInfo.Admin + "," + RoleInfo.Member)]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _productService.GetById(id);
            return Ok(products);
        }

        [HttpPost]
        [Authorize(Roles = RoleInfo.Admin + "," + RoleInfo.Member)]
        [ValidModel]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            await _productService.Add(_mapper.Map<Product>(productAddDto));
            return Created("", productAddDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleInfo.Admin)]
        [ValidModel]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _productService.Update(_mapper.Map<Product>(productUpdateDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleInfo.Admin)]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Remove(new Product() { Id = id});
            return NoContent();
        }

        [Route("/error")]
        public IActionResult Error()
        {
            return Problem(detail: "Api'de bir sorun oluştu. En kısa zamanda düzeltilecektir.");
        }
    }
}