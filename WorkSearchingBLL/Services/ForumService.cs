using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingBLL.DTOs;
using WorkSearchingBLL.Interfaces;
using WorkSearchingDAL.Entities;

namespace WorkSearchingBLL.Services
{
    public class ForumService : IForumService
    {
        private readonly WorkSearchingDAL.Interfaces.IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ForumService(WorkSearchingDAL.Interfaces.IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ForumDTO model)
        {
            model.Created = DateTime.Now;
            var forum = _mapper.Map<Forum>(model);
            await _unitOfWork.ForumRepository.AddAsync(forum);
            return 0;
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            try
            {
                await _unitOfWork.ForumRepository.DeleteByIdAsync(modelId);
            }
            catch (Exception ex)
            {

            }
            await _unitOfWork.SaveAsync();
        }

        public List<ForumDTO> Get()
        {
            var data = GetAll()
                .OrderByDescending(x => x.Title)
                .Select(f => new ForumDTO
                {
                    UserId = f.UserId,
                    Id = f.Id,
                    Title = f.Title,
                    Body = f.Body,
                    Created = f.Created
                }).ToList();

            

            return data;
        }

        public IEnumerable<ForumDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ForumDTO>>(_unitOfWork.ForumRepository.FindAll());
        }

        public IEnumerable<ForumDTO> FindByTitle(string title)
        {
            var forums = GetAll();

            var findingForums = forums.Where(x => x.Title.Contains(title));
            return findingForums;
        }

        public async Task<List<ForumDTO>> GetAllTopLevels()
        {
            var data = GetAll().ToList();
            return data;
        }

        public async Task<ForumDTO> GetByIdAsync(int id)
        {
            var forum = await _unitOfWork.ForumRepository.GetByIdAsync(id);

            if (forum == null)
                throw new Exception();

            return _mapper.Map<ForumDTO>(forum);
        }

        public async Task UpdateAsync(int id, ForumDTO model)
        {
            var forum = await GetByIdAsync(id);

            if (forum == null)
                throw new Exception();

            forum.Title = model.Title;
            forum.Body = model.Body;

            _unitOfWork.ForumRepository.Update(_mapper.Map<Forum>(forum));
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(ForumDTO model)
        {
            _unitOfWork.ForumRepository.Update(_mapper.Map<Forum>(model));

            await _unitOfWork.SaveAsync();
        }
       
    }
}
