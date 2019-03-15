using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Common.Dto;
using CodeChallenge.Common.Exceptions;
using CodeChallenge.Common.Mapping;
using CodeChallenge.DAL.Context;
using CodeChallenge.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.DAL.Repositories
{
    public class UserProjectRepository : BaseRepository<UserProject, int>, IUserProjectRepository
    {
        private readonly IMappingEngine _mapper;

        public UserProjectRepository(CodeChallengeContext dbContext, IMappingEngine mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<List<UserProjectDto>> GetAllUserProjectsByUserIdAsync(int userId)
        {
            var result = await Get().Include(up => up.Project).Where(ccup => ccup.UserId == userId).ToListAsync();

            if (!result.Any())
            {
                throw new CodeChallengeException(string.Empty, HttpStatusCode.NoContent);
            }

            var response = _mapper.Map<List<UserProject>, List<UserProjectDto>>(result);

            return response;
        }
    }
}
