using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrud.Domain.Dtos;
using BCrud.Domain.Entities;
using BCrud.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Common;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyllabusController : ControllerBase
    {
        private readonly ISyllabusRepository _syllabusRepository;

        public SyllabusController(ISyllabusRepository syllabusRepository)
        {
            _syllabusRepository = syllabusRepository;
        }

        [HttpPost]
        public ActionResult<Guid> Post(SyllabusDto dto)
        {
            return Ok(_syllabusRepository.AddSyllabus(dto.BindId(x => (Guid)x.Id)));            
        }

        [HttpPut]
        public ActionResult<Guid> Put(SyllabusDto dto)
        {
            _syllabusRepository.Update(dto);
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public ActionResult<SyllabusDto> Get([FromRoute] Guid id)
        {
            return Ok(_syllabusRepository.FindById(id));
        }

        public ActionResult<SyllabusDto> Get()
        {
            return Ok(_syllabusRepository.GetAll());
        }


    }
}