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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<ApplicationUser> _user;

        public UserRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _user = _dbContext.Set<ApplicationUser>();
        }

        public async Task AddAsync(ApplicationUser entity)
        {
            await _user.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(ApplicationUser entity)
        {
            _user.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<ApplicationUser> FindAll()
        {
            return _user.Include(x => x.Forums).Include(y => y.Forums);
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            var res = await _user.FirstOrDefaultAsync(x => x.Id == id); //.Include(x => x.Forums).Include(y => y.Comments)
            _dbContext.Entry(res).State = EntityState.Detached;
            return res;
        }

        public Task<ApplicationUser> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationUser entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
