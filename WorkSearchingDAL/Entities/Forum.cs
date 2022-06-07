using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSearchingDAL.Entities
{
    public class Forum
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }

        public virtual ApplicationUser User {get;set;}
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
