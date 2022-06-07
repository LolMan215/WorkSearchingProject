using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSearchingDAL.Entities;
using WorkSearchingDAL.Interfaces;

namespace WorkSearchingDAL.Repositories
{
    public class JobOfferRepository : IJobOfferRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<JobOffer> _jobOffer;

        public JobOfferRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _jobOffer = _dbContext.Set<JobOffer>();
        }

        public async Task AddAsync(JobOffer entity)
        {
            await _jobOffer.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(JobOffer entity)
        {
            _jobOffer.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<JobOffer> FindAll()
        {
            return _jobOffer.Include(x => x.Employer).Include(y =>y.User);
        }

        public async Task<JobOffer> GetByIdAsync(int id)
        {
            var res = await _jobOffer.Include(x => x.Employer).Include(y => y.User).FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Entry(res).State = EntityState.Detached;
            return res;
        }

        public void Update(JobOffer entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
