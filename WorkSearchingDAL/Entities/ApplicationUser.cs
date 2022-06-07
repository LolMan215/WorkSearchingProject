using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSearchingDAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Reputation { get; set; }

        public ICollection<Forum> Forums { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}
