using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingBLL.DTOs;

namespace WorkSearchingBLL.Interfaces
{
    public interface IUserService: ICrud<UserDTO>
    {
        Task updateReputation(string id, bool succes);

        Task<UserDTO> GetByIdAsync(string id);

        Task<List<JobOfferDTO>> GetAllOffersAcceptedByUser(string userId);
    }
}
