using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Common.Dto;

namespace CodeChallenge.BLL
{
    public interface IUserProjectsBll
    {
        Task<List<CodeChallengeUserDto>> GetAllUsersAsync();
    }
}
