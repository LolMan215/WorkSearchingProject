using System;
using System.Collections.Generic;
using System.Text;
using WorkSearchingDAL.Entities;

namespace WorkSearchingBLL.DTOs
{
    public class EmployerDTO: UserDTO
    {
        public string CompanyName { get; set; }

        public List<JobOffer> JobOffers { get; set; }
    }
}
