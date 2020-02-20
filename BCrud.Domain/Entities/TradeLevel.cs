using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCrud.Domain.Entities
{
    public class TradeLevel
    {

        private TradeLevel()
        {
            _syllabuses = new HashSet<Syllabus>();
        }
        [JsonConstructor]
        public TradeLevel(Guid id, string title, Guid tradeId)
        {
            _id = id;
            _title = title;
            _tradeId = TradeId;
            _syllabuses = new HashSet<Syllabus>();
        }

        private Guid _id;
        [Key]
        public Guid Id => _id;

        private string _title;        
        public string Title => _title;

        private Guid _tradeId;
        public Guid TradeId => _tradeId;

        private Trade _trade;
        public Trade Trade => _trade;

        private ICollection<Syllabus> _syllabuses;
        public ICollection<Syllabus> Syllabusses;
    }
}
