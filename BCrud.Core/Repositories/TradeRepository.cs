﻿
using BCrud.Domain.Entities;
using BCrud.Domain.Repositories;
using BCrud.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCrud.Core.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly DatabaseContext _context;

        public TradeRepository(DatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Trade> GetTrades()
        {
            return _context.Trades.ToList();
        }
    }
}
