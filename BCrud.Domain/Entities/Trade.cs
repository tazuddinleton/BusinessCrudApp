using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCrud.Domain.Entities
{
    public class Trade
    {

        private Trade()
        {
            _tradeLevels = new HashSet<TradeLevel>();
            _syllabuses = new HashSet<Syllabus>();
        }

        [JsonConstructor]
        public Trade(Guid id, string title)
        {
            _id = id;
            _title = title;
            _tradeLevels = new HashSet<TradeLevel>();
            _syllabuses = new HashSet<Syllabus>();
        }

        private Guid _id;
        [Key]
        public Guid Id => _id;

        private string _title;        
        public string Title => _title;
        
        private ICollection<TradeLevel> _tradeLevels;
        public ICollection<TradeLevel> TradeLevels => _tradeLevels;

        private ICollection<Syllabus> _syllabuses;
        public ICollection<Syllabus> Syllabusses;
    }
}
