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
    public class ExperienceUnitRepository : IExperienceUnitRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<ExperienceUnit> _expUnit;

        public ExperienceUnitRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _expUnit = _dbContext.Set<ExperienceUnit>();
        }

        public async Task AddAsync(ExperienceUnit entity)
        {
            await _expUnit.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(ExperienceUnit entity)
        {
           _expUnit.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<ExperienceUnit> FindAll()
        {
            return _expUnit;
        }

        public async Task<ExperienceUnit> GetByIdAsync(int id)
        {
            var res = await _expUnit.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Entry(res).State = EntityState.Detached;
            return res;
        }

        public void Update(ExperienceUnit entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
