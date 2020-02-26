using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrud.Domain.Dtos;
using BCrud.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCrud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeLevelController : ControllerBase
    {
        private readonly ITradeLevelRepository _tradeLevelRepository;
        public TradeLevelController(ITradeLevelRepository tradeLevelRepository)
        {
            _tradeLevelRepository = tradeLevelRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            return Ok(_tradeLevelRepository.GetTradeLevels());
        }
    }
}