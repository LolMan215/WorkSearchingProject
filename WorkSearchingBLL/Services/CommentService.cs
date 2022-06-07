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
    public class CommentService : ICommentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CommentDTO model)
        {
            model.Created = DateTime.Now;
            var storedComment = _mapper.Map<Comment>(model);
            _unitOfWork.CommentRepository.AddAsync(storedComment);
            await _unitOfWork.SaveAsync();
            return storedComment.Id;
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            try
            {
                await _unitOfWork.CommentRepository.DeleteByIdAsync(modelId);
            }
            catch (Exception ex)
            {

            }
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<CommentDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<CommentDTO>>(_unitOfWork.CommentRepository.FindAll());

        }

        public async Task<List<CommentDTO>> GetByForumId(int id)
        {
            var data =  GetAll()
                .OrderBy(x => x.Created)
                .Where(y => y.ForumId == id)
                .ToList();
   
            return data;
        }

        public async Task<CommentDTO> GetByIdAsync(int id)
        {
            var res = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            return _mapper.Map<CommentDTO>(res);
        }

        public Task UpdateAsync(int id, CommentDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CommentDTO model)
        {
            var comment = await GetByIdAsync(model.Id);

            if (comment == null)
                throw new Exception();

            comment.Body = model.Body;

            await UpdateAsync(comment);
        }
    }
}
