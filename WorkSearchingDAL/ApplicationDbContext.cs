using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using WorkSearchingDAL.Entities;

namespace WorkSearchingDAL
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ApplicationUser> Userss { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<CV> CVs { get; set; }
        public virtual DbSet<JobOffer> JobOffers { get; set; }
        public virtual DbSet<LanguageUnit> LanguageUnits { get; set; }
        public virtual DbSet<ExperienceUnit> ExperienceUnits { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }


        public ApplicationDbContext(
          DbContextOptions options,
          IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }


    }
}
