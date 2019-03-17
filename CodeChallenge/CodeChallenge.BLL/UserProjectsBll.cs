using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Common.Dto;
using CodeChallenge.Common.Mapping;
using CodeChallenge.DAL.Repositories;

namespace CodeChallenge.BLL
{
    public class UserProjectsBll : IUserProjectsBll
    {
        private readonly IMappingEngine _mapper;
        private readonly IUserRepository _codeChallengeUserRepository;
        private readonly IUserProjectRepository _userProjectRepository;

        public UserProjectsBll(IUserRepository codeChallengeUserRepository, IUserProjectRepository userProjectRepository, IMappingEngine mapper)
        {
            _mapper = mapper;
            _codeChallengeUserRepository = codeChallengeUserRepository;
            _userProjectRepository = userProjectRepository;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var response = await _codeChallengeUserRepository.GetAllUsersAsync();

            return response;
        }

        public async Task<List<UserProjectCalculatedDto>> GetAllUserProjectsCalculatedAsync(int userId)
        {
            var userProjects = await _userProjectRepository.GetAllUserProjectsByUserIdAsync(userId);

            var response = _mapper.Map<List<UserProjectDto>, List<UserProjectCalculatedDto>>(userProjects);

            return response;
        }
    }
}
