using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Common.Dto;

namespace CodeChallenge.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllUsersAsync();
    }
}
