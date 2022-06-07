using System;
using System.Collections.Generic;

namespace WorkSearchingDAL.Entities
{
    public class JobOffer
    {
        public int Id { get; set; }

        public Guid EmployerId { get; set; }

        public Guid? ApplicationUser { get; set; }

        public string OfferPosition { get; set; }

        public string OfferBody { get; set; }

        public DateTime CereatedTime { get; set; }

        public virtual Employer Employer { get; set; }

        public virtual ICollection<ApplicationUser> User { get; set; }
    }
}