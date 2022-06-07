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
    public class LanguageUnitRepository : ILanguageUnitRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<LanguageUnit> _languageUnit;

        public LanguageUnitRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _languageUnit = _dbContext.Set<LanguageUnit>();
        }

        public async Task AddAsync(LanguageUnit entity)
        {
            await _languageUnit.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(LanguageUnit entity)
        {
            _languageUnit.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<LanguageUnit> FindAll()
        {
            return _languageUnit;
        }

        public async Task<LanguageUnit> GetByIdAsync(int id)
        {
            return await _languageUnit.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(LanguageUnit entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
