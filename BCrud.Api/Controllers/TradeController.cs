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
    public class TradeController : ControllerBase
    {

        private readonly ITradeRepository _tradeRepository;
        public TradeController(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }



        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            return Ok(_tradeRepository.GetTrades());
        }

    }


}