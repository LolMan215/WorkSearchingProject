using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingBLL.DTOs;

namespace WorkSearchingBLL.Interfaces
{
    public interface IEmployerService: IUserService
    {
        Task<List<JobOfferDTO>> GetAllOffersByEmployerId(string id);
    }
}
