using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingDAL.Entities;

namespace WorkSearchingDAL.Interfaces
{
    public interface IEmployerRepository: IRepository<Employer>
    {
        Task<Employer> GetByIdAsync(string id);

        Task DeleteByIdAsync(string id);
    }
}
