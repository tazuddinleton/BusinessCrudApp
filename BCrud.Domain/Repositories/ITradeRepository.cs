﻿
using BCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Domain.Repositories
{
    public interface ITradeRepository
    {
        IEnumerable<Trade> GetTrades();
    }
}
