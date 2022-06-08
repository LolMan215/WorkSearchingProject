using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingBLL.DTOs;
using WorkSearchingBLL.Interfaces;

namespace WorkSearchingBLL.Services
{
    public class ImageService : IImageService
    {
        public Task<int> AddAsync(ImageDTO model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImageDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ImageDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ImageDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
