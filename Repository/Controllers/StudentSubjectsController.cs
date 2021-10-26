using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models;
using Repository.Models.Interfaces;
using Repository.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectsController : BaseController<StudentSubjects, StudentSubjectsResponse>
    {
        public StudentSubjectsController(DataContext _context, IRepository<StudentSubjects> _repository, IMapper _mapper) : base(_context, _repository, _mapper)
        {
        }

        [NonAction]
        public override bool Validate(StudentSubjects request, bool Edit = false)
        {
            return !repository.Get().Any(ss => ss.IdStudent == request.IdStudent &&
                                              ss.IdSubject == request.IdSubject);
        }

        [NonAction]
        public override bool Exists(StudentSubjects request)
        {
            return repository.Get().Any(ss => ss.IdStudent == request.IdStudent &&
                                              ss.IdSubject == request.IdSubject);
        }
    }
}
