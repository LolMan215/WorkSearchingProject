using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingBLL.DTOs;

namespace WorkSearchingBLL.Interfaces
{
    public interface ICVService: ICrud<CVDTO>
    {
        Task<int> AddAsync(CVDTO model, List<ExperienceUnitDTO> experiences, List<LanguageUnitDTO> languages, List<SkillDTO> skills);

        Task<CVDTO> GetCVByUserId(string userId);

        Task UpdateAsync(int id, CVDTO model);
    }
}
