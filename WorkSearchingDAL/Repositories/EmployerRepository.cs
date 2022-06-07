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
    public class EmployerRepository : IEmployerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<Employer> _employer;

        public EmployerRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _employer = _dbContext.Set<Employer>();
        }

        public async Task AddAsync(Employer entity)
        {
            await _employer.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Employer entity)
        {
            _employer.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Employer> FindAll()
        {
            return _employer.Include(x => x.Forums).Include(x => x.JobOffers);
        }

        public async Task<Employer> GetByIdAsync(string id)
        {
            var res = await _employer.Include(x => x.Forums).Include(z => z.JobOffers).FirstOrDefaultAsync(y => y.Id == id);
            _dbContext.Entry(res).State = EntityState.Detached;
            return res;
        }

        public Task<Employer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employer entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
