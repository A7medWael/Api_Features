using AutoMapper;
using Cores.DToS;
using Cores.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cores.Entities;
namespace ApiDemoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketReposatory _basketReposatory;
        private readonly IMapper _mapper;

        public BasketController(IBasketReposatory basketReposatory,IMapper mapper)
        {
            _basketReposatory = basketReposatory;
            _mapper = mapper;
        }
        [HttpGet("GetBasketById")]
        public async Task<ActionResult<CustomerDto>> GetBasketById(string basketid )
        {
           var bas= await _basketReposatory.GetBusketAsync(basketid);
            return Ok(bas ?? new CustomerBusket(basketid));

        }
        [HttpPost("UpdateCustomerBasket")]
        public async Task<ActionResult<CustomerBusket>> UpdateCustomerBasket(CustomerDto customerDto)
        {
            var basket=_mapper.Map<CustomerBusket>(customerDto);
            var UpdatedBasket=_basketReposatory.UpdateBusketAsync(basket);
            return Ok(UpdatedBasket);
        }
        [HttpDelete]
        public async Task DeleteById(string Id)
        {
            await _basketReposatory.DeleteBusketAsync(Id);
        }
    }
}
