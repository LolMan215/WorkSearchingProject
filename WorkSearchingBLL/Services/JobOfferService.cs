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
    public class JobOfferService : IJobOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobOfferService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AcceptOffer(int offerId, string userId)
        {
            var offer = await GetByIdAsync(offerId);
            offer.ApplicationUser = userId;

            await UpdateAsync(offer);
        }

        public async Task<int> AddAsync(JobOfferDTO model)
        {
            model.CereatedTime = DateTime.Now;

            var offer = _mapper.Map<JobOffer>(model);

            await _unitOfWork.JobOfferRepository.AddAsync(offer);

            return 0;
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            try
            {
                await _unitOfWork.JobOfferRepository.DeleteByIdAsync(modelId);
            }
            catch (Exception ex)
            {

            }
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<JobOfferDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<JobOfferDTO>>(_unitOfWork.JobOfferRepository.FindAll());
        }

        public async Task<List<JobOfferDTO>> GetAllTop()
        {
            var data =  GetAll().ToList();
            return data;
        }

        public async Task<List<JobOfferDTO>> GetOffersByPosition(string position)
        {
            var data = GetAll();
            return data.Where(x => x.OfferPosition.Contains(position)).ToList();
        }

        public async Task<JobOfferDTO> GetByIdAsync(int id)
        {
            var offer = await _unitOfWork.JobOfferRepository.GetByIdAsync(id);

            if (offer == null)
                throw new Exception();

            return _mapper.Map<JobOfferDTO>(offer);
        }

        public async Task UpdateAsync(JobOfferDTO model)
        {
            _unitOfWork.JobOfferRepository.Update(_mapper.Map<JobOffer>(model));

            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(int id, JobOfferDTO model)
        {
            _unitOfWork.JobOfferRepository.Update(_mapper.Map<JobOffer>(model));

            await _unitOfWork.SaveAsync();
        }
    }
}
