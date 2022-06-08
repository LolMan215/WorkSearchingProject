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
    public class EmployerService : IEmployerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(UserDTO model)
        {
            model.Reputation = 50;

            var user = _mapper.Map<WorkSearchingDAL.Entities.ApplicationUser>(model);

            await _unitOfWork.UserRepository.AddAsync(user);

            return 0;
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            try
            {
                await _unitOfWork.EmployRepository.DeleteByIdAsync(modelId);
            }
            catch (Exception ex)
            {

            }
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(string modelId)
        {
            try
            {
                await _unitOfWork.EmployRepository.DeleteByIdAsync(modelId);
            }
            catch (Exception ex)
            {

            }
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_unitOfWork.UserRepository.FindAll());
        }

        public Task<List<JobOfferDTO>> GetAllOffersAcceptedByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobOfferDTO>> GetAllOffersByEmployerId(string id)
        {
            var offers = _unitOfWork.JobOfferRepository
                .FindAll()
                .Select(x => _mapper.Map<JobOfferDTO>(x))
                .Where(y => y.EmployerId == id).ToList();

            return offers;
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetByIdAsync(string id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public Task<UserDTO> GetUserByForumTitle(string title)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserDTO model)
        {
            _unitOfWork.UserRepository.Update(_mapper.Map<ApplicationUser>(model));

            await _unitOfWork.SaveAsync();
        }

        public async Task updateReputation(string id, bool succes)
        {
            var user = await GetByIdAsync(id);
            if (user.Reputation > 0 && user.Reputation < 100)
            {
                if (succes)
                {
                    user.Reputation += 10;
                }
                else
                {
                    user.Reputation -= 10;
                }
                await UpdateAsync(user);
            }
        }
    }
}

