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
    public class StudentsController : BaseController<Students, StudentsResponse>
    {
        public StudentsController(DataContext _context, IRepository<Students> _repository, IMapper _mapper) : base(_context, _repository, _mapper)
        {
        }

        [NonAction]
        public override Students Transform(Students entity)
        {
            entity.Name = entity.Name.Trim();
            entity.Name = char.ToUpper(entity.Name[0]) + entity.Name.Substring(1);

            entity.Lastname = entity.Lastname.Trim();
            entity.Lastname = char.ToUpper(entity.Lastname[0]) + entity.Lastname.Substring(1);

            entity.StudentCode = entity.StudentCode.Trim().ToUpper();
            return entity;
        }

        [NonAction]
        public override bool Exists(Students entity)
        {
            return repository.Get().Any(s => s.Name        == entity.Name &&
                                             s.Lastname    == entity.Lastname &&
                                             s.StudentCode == entity.StudentCode);
        }

        [NonAction]
        public override bool Validate(Students request, bool Edit = false)
        {  
            return !repository.Get().Any(s => s.StudentCode == request.StudentCode);
        }
    }
}
