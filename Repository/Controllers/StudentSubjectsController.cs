using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Data.DataStrings;
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

        /// <summary>
        /// get all Subjects of a student.
        /// </summary>
        /// <param name="IdStudent"></param>
        [HttpGet("{IdStudent}")]
        public ActionResult<ApiResponses> GetByStudent(int IdStudent)
        {
            ApiResponses response = new ApiResponses()
            {
                Success = true,
                Message = MessageResponse.Response_Success
            };

            try
            {
                IEnumerable<StudentSubjects> Data = repository.Get()
                                                              .Where(ss => ss.IdStudent == IdStudent)
                                                              .Select(x => mapper.Map<StudentSubjects>(x));
                response.Data = Data;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.Success = false;
            }

            return response;
        }

        /// <summary>
        /// get all students who take a subject
        /// </summary>
        /// <param name="IdSubject"></param>
        [HttpGet("{IdSubject}")]
        public ActionResult<ApiResponses> GetBySubject(int IdSubject)
        {
            ApiResponses response = new ApiResponses()
            {
                Success = true,
                Message = MessageResponse.Response_Success
            };

            try
            {
                IEnumerable<StudentSubjects> Data = repository.Get()
                                                              .Where(ss => ss.IdSubject == IdSubject)
                                                              .Select(x => mapper.Map<StudentSubjects>(x));
                response.Data = Data;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.Success = false;
            }

            return response;
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
