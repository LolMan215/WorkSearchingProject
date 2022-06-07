using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSearchingBLL.DTOs
{
    public class ForumDTO
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? Created { get; set; }

        public UserDTO? User { get; set; }
        public List<CommentDTO>? Comments { get; set; }
    }
}
