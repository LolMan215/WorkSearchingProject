using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingBLL.DTOs;
using WorkSearchingDAL.Entities;

namespace WorkSearchingBLL.Interfaces
{
    public interface ICommentService: ICrud<CommentDTO>
    {
        Task<List<CommentDTO>> GetByForumId(int id);

        Task UpdateAsync(int id, CommentDTO model);
    }
}
