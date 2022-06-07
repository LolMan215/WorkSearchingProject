using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingBLL.DTOs;

namespace WorkSearchingBLL.Interfaces
{
    public interface IJobOfferService : ICrud<JobOfferDTO>
    {
        Task AcceptOffer(int offerId, string userId);

        Task<List<JobOfferDTO>> GetAllTop();

        Task UpdateAsync(int id, JobOfferDTO model);
    }
}
