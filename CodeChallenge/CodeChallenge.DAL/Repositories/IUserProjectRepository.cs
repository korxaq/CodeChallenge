using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Common.Dto;

namespace CodeChallenge.DAL.Repositories
{
    public interface IUserProjectRepository
    {
        Task<List<UserProjectDto>> GetAllUserProjectsByUserIdAsync(int userId);
    }
}
