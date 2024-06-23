using ApiDemoo.ResponseMedule;
using Infrastructures.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public BuggyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("TestText")]
        [Authorize]
        public ActionResult<string> GetText()
        {

            return "Some Text";
        }
        [HttpGet("GetNOtFound")]
        public ActionResult GetNotFoundRequest()
        {
            var AnyThing = _dbContext.Products.Find(1000);
            if (AnyThing == null)
                return NotFound(new ApiResponses(404));
            return Ok();
           
        }
        [HttpGet("GetBadRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponses(400));
        }
    }
}
