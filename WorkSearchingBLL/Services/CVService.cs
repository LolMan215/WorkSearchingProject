using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingBLL.DTOs;
using WorkSearchingBLL.Interfaces;
using WorkSearchingDAL.Entities;
using WorkSearchingDAL.Interfaces;

namespace WorkSearchingBLL.Services
{
    public class CVService : ICVService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CVService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CVDTO model)
        {        

            var offer = _mapper.Map<CV>(model);

            await _unitOfWork.CVRepository.AddAsync(offer);

            return 0;
        }

        public async Task<int> AddAsync(CVDTO model, List<ExperienceUnitDTO> experiences, List<LanguageUnitDTO> languages, List<SkillDTO> skills)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(model.UserId);

            var exp = experiences.Select(x => _mapper.Map<ExperienceUnit>(experiences)).ToList();
            var lang = languages.Select(x => _mapper.Map<LanguageUnit>(languages)).ToList();
            var skil = skills.Select(x => _mapper.Map<Skill>(skills)).ToList();

            var cv = new CV
            {
                Education = model.Education,
                UserId = Guid.Parse(model.UserId),
                FullName = model.FullName,
                Description = model.Description,
                Experience = exp,
                Languages = lang,
                Skills = skil
            };
            await _unitOfWork.CVRepository.AddAsync(cv);
            return 0;
        }



        public async Task DeleteByIdAsync(int modelId)
        {
            try
            {
                await _unitOfWork.CVRepository.DeleteByIdAsync(modelId);
            }
            catch (Exception ex)
            {

            }
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<CVDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<CVDTO>>(_unitOfWork.CVRepository.FindAll());
        }

        public Task<CVDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CVDTO> GetCVByUserId(string userId)
        {
            var cv = GetAll().FirstOrDefault(x => x.UserId == userId);

            return cv;
        }

        public async Task UpdateAsync(CVDTO model)
        {
            _unitOfWork.CVRepository.Update(_mapper.Map<CV>(model));

            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(int id, CVDTO model)
        {
            _unitOfWork.CVRepository.Update(_mapper.Map<CV>(model));

            await _unitOfWork.SaveAsync();
        }
    }
}
