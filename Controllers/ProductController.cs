using ApiDemoo.ResponseMedule;
using AutoMapper;
using Cores.Entities;
using Cores.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IGenericRepository<Product> _repository;
        //private readonly IGenericRepository<ProductBrand> _repositoryBrand;
        //private readonly IGenericRepository<ProductType> _repositoryTyp;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork/* IGenericRepository<Product> repository, IGenericRepository<ProductBrand> repositoryBrand,*/
           /*IGenericRepository<ProductType> repositoryTyp*/, IMapper mapper)
        {
            //_repository=repository;
            //_repositoryBrand=repositoryBrand;
            //_repositoryTyp=repositoryTyp;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpGet("GetProducts")]
        public async Task< ActionResult<IReadOnlyList<ProductDto>>> GetProducts(int? typeid,int? brandid,string? sortDta)
        {
            if (brandid == null || typeid == null)
            {
                if(sortDta == null)
                {
                    //return await _repository.GetAsync(includeWord: "ProductBrand,ProductType");
                    var prod = await _unitOfWork.ProdtRepos.GetAsync(includeWord: "ProductBrand,ProductType");
                    var mapprod = _mapper.Map<IReadOnlyList<ProductDto>>(prod);
                  
                    return Ok(mapprod);
                }else if (sortDta == "NameAsc")
                {
                    //return await _repository.GetAsync(includeWord: "ProductBrand,ProductType");
                    var prod = await _unitOfWork.ProdtRepos.GetAsync(includeWord: "ProductBrand,ProductType");
                    var mapprod = _mapper.Map<IReadOnlyList<ProductDto>>(prod);
                    var m = mapprod.OrderBy(x => x.Name).ToList();
                    return Ok(m);
                }else if(sortDta == "NameDesc")
                {
                    //return await _repository.GetAsync(includeWord: "ProductBrand,ProductType");
                    var prod = await _unitOfWork.ProdtRepos.GetAsync(includeWord: "ProductBrand,ProductType");
                    var mapprod = _mapper.Map<IReadOnlyList<ProductDto>>(prod);
                    var m = mapprod.OrderByDescending(x =>x.Name).ToList();
                    return Ok(m);
                }

                return Ok();
            }
            else
            {
                var prod= await _unitOfWork.ProdtRepos.GetAsync(x =>  x.ProductTypeId == typeid && x.ProductBrandId == brandid , includeWord:"ProductBrand,ProductType");
                var mapprod = _mapper.Map<IReadOnlyList<ProductDto>>(prod);
                return Ok(mapprod);
            }


        }
        [HttpGet("GetProdById")]
        //[HttpPut( "{id}")]
        [ProducesResponseType(typeof(ApiResponses), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProdById(int? id)
        {
           var prod= await _unitOfWork.ProdtRepos.GetbyIdAsync(x => x.Id == id);
            if (prod == null)
            {
                return NotFound(new ApiResponses(404));
            }
            else
            {
                return prod;
            }
            

        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>> AddProduct(AddProduct product)
        {
            var mapproduct=_mapper.Map<Product>(product);
            _unitOfWork.ProdtRepos.Add(mapproduct);
            _unitOfWork.Compelete();

            return Ok(product);


        }

        //[HttpGet("GetBrands")]
        //public async Task<IReadOnlyList<ProductBrand>> GetBrands()
        //{
        //    return await _repositoryBrand.GetAsync();

        //}

        //[HttpGet("GetTypes")]
        //public async Task<IReadOnlyList<ProductType>> GetTypes()
        //{
        //    return await _repositoryTyp.GetAsync();

        //}
    }
}
