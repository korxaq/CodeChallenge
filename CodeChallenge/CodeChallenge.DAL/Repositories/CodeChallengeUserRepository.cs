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
    public class CodeChallengeUserRepository : BaseRepository<CodeChallengeUser, int>, ICodeChallengeUserRepository
    {
        private readonly IMappingEngine _mapper;

        public CodeChallengeUserRepository(CodeChallengeContext dbContext, IMappingEngine mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<List<CodeChallengeUserDto>> GetAllUsersAsync()
        {
            var result = await Get().ToListAsync();

            if (!result.Any())
            {
                throw new CodeChallengeException(string.Empty, HttpStatusCode.NoContent);
            }

            var response = _mapper.Map<List<CodeChallengeUser>, List<CodeChallengeUserDto>>(result);

            return response;
        }
    }
}
