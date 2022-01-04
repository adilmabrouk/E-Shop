using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGeniricRepository<Product> ProductRep;
        private readonly IGeniricRepository<ProductBrand> BrandRep;
        private readonly IGeniricRepository<ProductType> TypeRep;
        private readonly IMapper mapper;

        public ProductsController(IGeniricRepository<Product> geniricRepository , IGeniricRepository<ProductBrand> brandRep, 
            IGeniricRepository<ProductType> TypeRep, IMapper mapper)
        {
            this.ProductRep = geniricRepository;
            this.BrandRep = brandRep;   
            this.TypeRep = TypeRep;
            this.mapper = mapper;
        }

        [HttpGet]   
        public async Task<ActionResult<IReadOnlyList<ProductToReturn>>> GetProducts()
        {
            var spec = new ProductWithBrandAndTypeSpecification();
            var products = await ProductRep.ListAllAsync(spec);
            return Ok(mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturn>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ProductToReturn> GetProductById(int id)
        {
            var spec = new ProductWithBrandAndTypeSpecification(id);
            var product = await ProductRep.GetEntityWithSpecAsync(spec);
            return mapper.Map<Product,ProductToReturn>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await BrandRep.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            var types = await TypeRep.GetAllAsync();
            return Ok(types);
        }
    }
}
