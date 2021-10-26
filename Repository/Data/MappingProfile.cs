using AutoMapper;
using Repository.Models;
using Repository.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Subjects, SubjectsResponse>().ReverseMap();

            CreateMap<Students, StudentsResponse>().ReverseMap();

            CreateMap<StudentSubjects, StudentSubjectsResponse>().ReverseMap();
        }
    }
}
