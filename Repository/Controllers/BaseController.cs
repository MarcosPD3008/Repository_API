using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Data.DataStrings;
using Repository.Models;
using Repository.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TResponse> : ControllerBase where T : class
                                                               where TResponse : class
    {
        public readonly DataContext context;
        public readonly IMapper mapper;
        public IRepository<T> repository;

        public BaseController(DataContext _context, IRepository<T> _repository, IMapper _mapper)
        {
            context = _context;
            repository = _repository;
            mapper = _mapper;
        }

        // GET: api/[Controller]
        [HttpGet]
        public ActionResult<ApiResponses> GetEntity()
        {
            ApiResponses response = new ApiResponses()
            {
                Success = true,
                Message = MessageResponse.Response_Success
            };

            try
            {
                IEnumerable<TResponse> Data = repository.Get().Select(x => mapper.Map<TResponse>(x));
                response.Data = Data;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.Success = false;
            }

            return response;
        }

        // GET: api/[Controller]/1 
        [HttpGet("{Id}")]
        public virtual ActionResult<ApiResponses> GetEntity([FromQuery] int Id)
        {
            ApiResponses response = new ApiResponses()
            {
                Message = MessageResponse.Response_Success,
                Success = true
            };

            try
            {
                response.Data = mapper.Map<TResponse>(repository.Get(Id));
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.Success = false;
            }

            return response;
        }

        // PUT: api/[Controller]/
        [HttpPut]
        public virtual ActionResult<ApiResponses> PutEntity([FromQuery] int Id, TResponse _request)
        {
            ApiResponses response = new ApiResponses()
            {
                Success = true,
                Message = MessageResponse.Response_Success
            };

            T request = null;

            try
            {
                if (!Exists(Id))
                {
                    response.Message = MessageResponse.Object_NotExists;
                    response.Success = false;
                    return response;
                }
                else
                {
                    request = mapper.Map(_request, repository.Get(Id));
                }

                if (!Validate(request, true))
                {
                    response.Success = false;
                    response.Message = String.Format(MessageResponse.Invalid_Object, request.ToString());
                    return response;
                }

                repository.Update(request);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                response.Success = false;
                response.Message = ex.Message.ToString();
            }

            return response;
        }

        // POST: api/Base
        [HttpPost]
        public virtual ActionResult<ApiResponses> PostEntity(T request)
        {
            ApiResponses response = new ApiResponses()
            {
                Success = true,
                Message = MessageResponse.Response_Success
            };

            try
            {
                if (!Validate(request))
                {
                    response.Message = String.Format(MessageResponse.Invalid_Object, request.ToString());
                    response.Success = false;
                    return response;
                }

                request = Transform(request);
                repository.Insert(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.Success = false;
            }

            return response;
        }

        // DELETE: api/Base/5
        [HttpDelete]
        public virtual ActionResult<ApiResponses> DeleteEntity([FromQuery] int Id)
        {
            ApiResponses response = new ApiResponses()
            {
                Success = true,
                Message = MessageResponse.Response_Success
            };

            try
            {
                if (!Exists(Id))
                {
                    response.Message = MessageResponse.Object_NotExists;
                    response.Success = false;
                    return response;
                }

                repository.Delete(repository.Get(Id));
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.Success = false;
            }

            return response;
        }

        [NonAction]
        public virtual bool Exists(int id)
        {
            return repository.Get(id) != null;
        }

        [NonAction] //validates if an object exists when more properties than id is needed.
        public virtual bool Exists(T entity)
        {
            return true;
        }

        [NonAction] //Validate if an object is ready to be inserted or updated
        public virtual bool Validate(T request, Boolean Edit = false)
        {
            return true;
        }

        [NonAction] //Transform the object's properties before being inserted
        public virtual T Transform(T entity)
        {
            return entity;
        }
    }

}
