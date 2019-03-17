using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Common.Dto;

namespace CodeChallenge.BLL
{
    public interface IUserProjectsBll
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<List<UserProjectCalculatedDto>> GetAllUserProjectsCalculatedAsync(int userId);
    }
}
