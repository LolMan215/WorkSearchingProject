using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSearchingDAL.Entities
{
    public class Employer : ApplicationUser
    {
        public string CompanyName { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }
    }
}
