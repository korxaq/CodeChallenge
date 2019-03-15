using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodeChallenge.Common.Dto;
using CodeChallenge.Common.Exceptions;
using CodeChallenge.Common.Mapping;
using CodeChallenge.DAL.Context;
using CodeChallenge.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.DAL.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        private readonly IMappingEngine _mapper;

        public UserRepository(CodeChallengeContext dbContext, IMappingEngine mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var result = await Get().ToListAsync();

            if (!result.Any())
            {
                throw new CodeChallengeException(string.Empty, HttpStatusCode.NoContent);
            }

            var response = _mapper.Map<List<User>, List<UserDto>>(result);

            return response;
        }
    }
}
