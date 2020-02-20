using BCrud.Domain.Dtos;
using BCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Domain.Repositories
{
    public interface ITradeLevelRepository
    {
        IEnumerable<TradeLevel> GetTradeLevels();
    }
}
