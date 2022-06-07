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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> AddAsync(UserDTO model)
        {
            model.Reputation = 50;
            model.Created = DateTime.Now;

            var user = _mapper.Map<ApplicationUser>(model);

            await _unitOfWork.UserRepository.AddAsync(user);

            return 0;
        }

 

        public async Task DeleteByIdAsync(int modelId)
        {
            try
            {
                await _unitOfWork.UserRepository.DeleteByIdAsync(modelId);
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

        public async Task<List<JobOfferDTO>> GetAllOffersAcceptedByUser(string userId)
        {
            var offers = _unitOfWork.JobOfferRepository
                .FindAll()
                .Select(x => _mapper.Map<JobOfferDTO>(x))
                .Where(y => y.ApplicationUser == userId)
                .ToList();

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

        public async Task UpdateAsync(UserDTO model)
        {
            _unitOfWork.UserRepository.Update(_mapper.Map<ApplicationUser>(model));

            await _unitOfWork.SaveAsync();
        }

        public async Task updateReputation(string id, bool succes)
        {
            var user = await GetByIdAsync(id);
            if(user.Reputation > 0 && user.Reputation < 100)
            {
                if (succes)
                {
                    user.Reputation += 10;
                }
                else
                {
                    user.Reputation -=10;
                }
                await UpdateAsync(user);
            }
        }
    }
}
