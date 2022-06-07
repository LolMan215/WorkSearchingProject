using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkSearchingDAL.Interfaces
{
    public interface IUnitOfWork
    {
        IForumRepository ForumRepository { get; }
        ICommentRepository CommentRepository { get; }
        ICVRepository CVRepository { get; }
        IEmployerRepository EmployRepository { get; }
        IExperienceUnitRepository ExperienceUnitRepository { get; }
        IJobOfferRepository JobOfferRepository { get; }
        ILanguageUnitRepository LanguageUnitRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveAsync();
    }
}
