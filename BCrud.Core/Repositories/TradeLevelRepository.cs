
using BCrud.Domain.Entities;
using BCrud.Domain.Repositories;
using BCrud.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BCrud.Core.Repositories
{
    public class TradeLevelRepository : ITradeLevelRepository
    {
        private readonly DatabaseContext _context;

        public TradeLevelRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<TradeLevel> GetTradeLevels()
        {
            return _context.TradeLevels                
                .ToList();
        }
    }
}
