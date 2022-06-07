using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WorkSearchingBLL.DTOs;
using WorkSearchingDAL.Entities;

namespace WorkSearchingBLL
{
    public class Automapper: Profile
    {
        public Automapper()
        {
            CreateMap<Forum, ForumDTO>()
                .ReverseMap();

            CreateMap<Comment, CommentDTO>()
                .ReverseMap();

            CreateMap<ApplicationUser, UserDTO>()
               .ReverseMap();

            CreateMap<Employer, EmployerDTO>()
              .ReverseMap();

            CreateMap<JobOffer, JobOfferDTO>()
              .ReverseMap();

            CreateMap<CV, CVDTO>()
              .ReverseMap();

            CreateMap<Skill, SkillDTO>()
              .ReverseMap();

            CreateMap<LanguageUnit, LanguageUnitDTO>()
              .ReverseMap();

            CreateMap<ExperienceUnit, ExperienceUnitDTO>()
              .ReverseMap();

        }
    }
}
