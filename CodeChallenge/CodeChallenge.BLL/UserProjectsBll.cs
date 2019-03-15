using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Common.Dto;
using CodeChallenge.DAL.Repositories;

namespace CodeChallenge.BLL
{
    public class UserProjectsBll : IUserProjectsBll
    {
        private readonly ICodeChallengeUserRepository _codeChallengeUserRepository;

        public UserProjectsBll(ICodeChallengeUserRepository codeChallengeUserRepository)
        {
            _codeChallengeUserRepository = codeChallengeUserRepository;
        }

        public async Task<List<CodeChallengeUserDto>> GetAllUsersAsync()
        {
            var response = await _codeChallengeUserRepository.GetAllUsersAsync();

            return response;
        }
    }
}
