using System;

namespace WorkSearchingDAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public Guid UserId { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }

        public virtual Forum Forum { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}