using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Api.Response;
using CodeChallenge.BLL;
using CodeChallenge.Common.MagicValues;
using CodeChallenge.Common.Mapping;
using CodeChallenge.Common.Dto;
using CodeChallenge.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        private readonly IMappingEngine _mapper;
        private readonly IUserProjectsBll _userProjectsBll;

        public UsersController(ILogger<UsersController> logger, IMappingEngine mapper, IUserProjectsBll userProjectsBll) : base(logger)
        {
            _mapper = mapper;
            _userProjectsBll = userProjectsBll;
        }

        
        [HttpGet]
        public async Task<ObjectResult> GetAllAsync()
        {
            ObjectResult response = CreateBadResponse(Constants.INVALID_REQUEST);

            try
            {
                var result = await _userProjectsBll.GetAllUsersAsync();

                var resultResponse = _mapper.Map<List<CodeChallengeUserDto>, List<CodeChallengeUserResponse>>(result);

                response = CreateOkResponse(resultResponse);
            }
            catch (CodeChallengeException exception)
            {
                response.StatusCode = (int?) exception.StatusCode;
                response.Value = exception.Message;
            }

            return response;
        }
    }
}
