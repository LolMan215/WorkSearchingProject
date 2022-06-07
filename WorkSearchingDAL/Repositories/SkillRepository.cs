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
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<Skill> _skills;

        public SkillRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _skills = _dbContext.Set<Skill>();
        }

        public async Task AddAsync(Skill entity)
        {
            await _skills.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Skill entity)
        {
            _skills.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<Skill> FindAll()
        {
            return _skills;
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _skills.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Skill entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
