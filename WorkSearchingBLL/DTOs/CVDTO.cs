using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSearchingBLL.DTOs
{
    public class CVDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }

        public List<SkillDTO> Skills { get; set; }
        public List<ExperienceUnitDTO> Experience { get; set; }
        public List<LanguageUnitDTO> Languages { get; set; }
    }
}
