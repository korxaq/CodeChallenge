using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Api.Controllers
{
    public abstract class BaseApiController : Controller
    {
        protected readonly ILogger<BaseApiController> Logger;

        protected BaseApiController(ILogger<BaseApiController> logger)
        {
            Logger = logger;
        }

        protected BadRequestObjectResult CreateBadResponse(string message)
        {
            var result = BadRequest(message);
            return result;
        }

        protected OkObjectResult CreateOkResponse(object value)
        {
            var result = Ok(value);
            return result;
        }

        protected NoContentResult NoContentResponse()
        {
            var result = NoContent();
            return result;
        }

        protected CreatedResult CreateCreatedResponse<TObject>(string uri, TObject value) where TObject : class
        {
            var result = Created(uri, value);
            return result;
        }

        protected NotFoundObjectResult CreateNotFoundResponse<TObject>(TObject value) where TObject : class
        {
            var result = NotFound(value);
            return result;
        }
    }
}