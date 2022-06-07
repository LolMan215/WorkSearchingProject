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
    public class CVRepository : ICVRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<CV> _cv;

        public CVRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _cv = _dbContext.Set<CV>();
        }

        public async Task AddAsync(CV entity)
        {
            await _cv.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(CV entity)
        {
            _cv.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<CV> FindAll()
        {
            return _cv.Include(x => x.Languages).Include(y => y.Experience).Include(z => z.Skills);
        }

        public async Task<CV> GetByIdAsync(int id)
        {
            var res = await _cv.Include(x => x.Languages).Include(y => y.Experience).Include(z => z.Skills).FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Entry(res).State = EntityState.Detached;
            return res;
        }

        public void Update(CV entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
