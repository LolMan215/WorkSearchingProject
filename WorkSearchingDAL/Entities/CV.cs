using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSearchingDAL.Entities
{
    public class CV
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<ExperienceUnit> Experience { get; set; }
        public virtual ICollection<LanguageUnit> Languages { get;set; }


    }
}
