using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingDAL.Entities;

namespace WorkSearchingDAL.Interfaces
{
    public interface IUserRepository: IRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetByIdAsync(string id);
    }
}
