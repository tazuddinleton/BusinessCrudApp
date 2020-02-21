using BCrud.Domain.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCrud.Domain.Entities
{
    public class Syllabus
    {
        
        private Guid _id;
        [Key]
        public Guid Id => _id;

        private string _name;        
        public string Name => _name;

        private Guid _tradeId;        
        public Guid TradeId => _tradeId;

        private Guid _tradeLevelId;
        public Guid TradeLevelId => _tradeLevelId;

        private string _languages;        
        public string Languages => _languages;

        private string _syllabusFilename;
        public string SyllabusFilename => _syllabusFilename;

        private string _syllabusUrl;        
        public string SyllabusUrl => _syllabusUrl;

        private string _testPlanFilename;
        public string TestPlanFilename => _testPlanFilename;

        private string _testPlanUrl;
        public string TestPlanUrl => _testPlanUrl;


        private string _devOfficer;        
        public string DevelopmentOfficer => _devOfficer;

        private string _manager;        
        public string Manager => _manager;

        private DateTime _activeDate;        
        public DateTime ActiveDate => _activeDate;


        private Trade _trade;
        public Trade Trade => _trade;

        private TradeLevel _tradeLevel;
        public TradeLevel TradeLevel => _tradeLevel;


        private Syllabus(){ }


        public Syllabus(Guid id, string name, Guid tradeId, Guid levelId,
           string languages,
           string syllabusFilename,
           string syllabusUrl,
           string testPlanFilename,
           string testPlanUrl,
           string devOfficer, 
           string manager, 
           DateTime activeDate
           )
        {

            if (string.IsNullOrEmpty(name))
                throw new ValidationError("Name is required.");

            if (string.IsNullOrEmpty(languages))
                throw new ValidationError("At least one language is required.");

            if (string.IsNullOrEmpty(devOfficer))
                throw new ValidationError("Development officer is required.");

            if (string.IsNullOrEmpty(manager))
                throw new ValidationError("Manager is required.");


            _id = id;
            _name = name;
            _tradeId = tradeId;
            _tradeLevelId = levelId;
            _languages = languages;
            _syllabusFilename = syllabusFilename;
            _syllabusUrl = syllabusUrl;
            _testPlanFilename = testPlanFilename;
            _testPlanUrl = testPlanUrl;
            _devOfficer = devOfficer;
            _manager = manager;
            _activeDate = activeDate;
        }
    }
}
