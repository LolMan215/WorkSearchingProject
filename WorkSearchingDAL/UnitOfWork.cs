
using System.Threading.Tasks;
using WorkSearchingDAL.Interfaces;
using WorkSearchingDAL.Repositories;

namespace WorkSearchingDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private IForumRepository _forumRepository;

        private ICommentRepository _commentRepository;

        private ICVRepository _cvRepository;

        private IEmployerRepository _employerRepository;

        private IExperienceUnitRepository _experienceUnitRepository;

        private IJobOfferRepository _jobOfferRepository;

        private ILanguageUnitRepository _languageUnitRepository;

        private IUserRepository _userRepository;

        private ISkillRepository _skillRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IForumRepository ForumRepository
        {
            get
            {
                if (_forumRepository == null)
                {
                    _forumRepository = new ForumRepository(_dbContext);
                }
                return _forumRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_dbContext);
                }
                return _commentRepository;
            }
        }

        public ICVRepository CVRepository
        {
            get
            {
                if (_cvRepository == null)
                {
                    _cvRepository = new CVRepository(_dbContext);
                }
                return _cvRepository;
            }
        }

        public IEmployerRepository EmployRepository
        {
            get
            {
                if (_employerRepository == null)
                {
                    _employerRepository = new EmployerRepository(_dbContext);
                }
                return _employerRepository;
            }
        }

        public IExperienceUnitRepository ExperienceUnitRepository
        {
            get
            {
                if (_experienceUnitRepository == null)
                {
                    _experienceUnitRepository = new ExperienceUnitRepository(_dbContext);
                }
                return _experienceUnitRepository;
            }
        }

        public IJobOfferRepository JobOfferRepository
        {
            get
            {
                if (_jobOfferRepository == null)
                {
                    _jobOfferRepository = new JobOfferRepository(_dbContext);
                }
                return _jobOfferRepository;
            }
        }

        public ILanguageUnitRepository LanguageUnitRepository
        {
            get
            {
                if (_languageUnitRepository == null)
                {
                    _languageUnitRepository = new LanguageUnitRepository(_dbContext);
                }
                return _languageUnitRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }

        public ISkillRepository SkillRepository
        {
            get
            {
                if (_skillRepository == null)
                {
                    _skillRepository = new SkillRepository(_dbContext);
                }
                return _skillRepository;
            }
        }
        public async Task<int> SaveAsync()
        {
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
