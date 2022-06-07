using System;

namespace WorkSearchingBLL.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public Guid UserId { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }

        public ForumDTO Forum { get; set; }
        public UserDTO User { get; set; }
    }
}