using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingBLL.DTOs;
using WorkSearchingDAL.Entities;

namespace WorkSearchingBLL.Interfaces
{
    public interface IForumService: ICrud<ForumDTO>
    {
        Task UpdateAsync(int id, ForumDTO model);

        Task<List<ForumDTO>> GetAllTopLevels();

        List<ForumDTO> Get();

        IEnumerable<ForumDTO> FindByTitle(string title);
    }
}
