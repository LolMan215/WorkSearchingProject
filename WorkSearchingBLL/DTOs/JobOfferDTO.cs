using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSearchingBLL.DTOs
{
    public class JobOfferDTO
    {
        public int Id { get; set; }

        public string EmployerId { get; set; }

        public string ApplicationUser { get; set; }

        public string OfferPosition { get; set; }

        public string OfferBody { get; set; }

        public DateTime CereatedTime { get; set; }


    }
}
