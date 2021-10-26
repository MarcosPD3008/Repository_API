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
    public class SubjectsController : BaseController<Subjects, SubjectsResponse>
    {
        public SubjectsController(DataContext _context, IRepository<Subjects> _repository, IMapper _mapper) : base(_context, _repository, _mapper)
        {
        }
        [NonAction]
        public override Subjects Transform(Subjects entity)
        {
            entity.Name = entity.Name.Trim();
            entity.Name = char.ToUpper(entity.Name[0]) + entity.Name.Substring(1);

            entity.SubjectCode = entity.SubjectCode.Trim().ToUpper();
            return entity;
        }

        [NonAction]
        public override bool Exists(Subjects entity)
        {
            return repository.Get().Any(s => s.Name        == entity.Name &&
                                             s.SubjectCode == entity.SubjectCode);
        }

        [NonAction]
        public override bool Validate(Subjects request, bool Edit = false)
        {
            return !repository.Get().Any(s => s.Name == request.Name ||
                                             s.SubjectCode == request.SubjectCode);
        }
    }
}
