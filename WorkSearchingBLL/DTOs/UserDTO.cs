using System;
using System.Collections.Generic;

namespace WorkSearchingBLL.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public DateTime? Created { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Reputation { get; set; }

        public List<ForumDTO> Forums { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}