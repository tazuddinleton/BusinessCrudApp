using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Domain.Dtos
{
    public class SyllabusDto
    {           
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid TradeId { get; set; }
        public string TradeName { get; set; }
        public Guid TradeLevelId { get; set; }
        public string TradeLevelName { get; set; }
        public string Languages { get; set; }
        public string SyllabusUrl { get; set; }
        public string TestPlanUrl { get; set; }
        public string DevelopmentOfficer { get; set; }
        public string Manager { get; set; }
        
        public DateTime ActiveDate { get; set; }

        
        public SyllabusDto() { }

        public SyllabusDto(Guid id, string name, Guid tradeId, Guid tradeLevelId, string languages, string syllabusUrl, string testPlanUrl, string developmentOfficer, string manager, DateTime activeDate)
        {
            Id = id;
            Name = name;
            TradeId = tradeId;
            TradeLevelId = tradeLevelId;
            Languages = languages;
            SyllabusUrl = syllabusUrl;
            TestPlanUrl = testPlanUrl;
            DevelopmentOfficer = developmentOfficer;
            Manager = manager;
            ActiveDate = activeDate;
        }

        public SyllabusDto(Guid id, string name, Guid tradeId, string tradeName,
            Guid tradeLevelId, string tradLevelName,  string languages, string syllabusUrl, string testPlanUrl, string developmentOfficer, string manager, DateTime activeDate)
        {
            Id = id;
            Name = name;
            TradeId = tradeId;
            TradeName = tradeName;
            TradeLevelId = tradeLevelId;
            TradeLevelName = tradLevelName;
            Languages = languages;
            SyllabusUrl = syllabusUrl;
            TestPlanUrl = testPlanUrl;
            DevelopmentOfficer = developmentOfficer;
            Manager = manager;
            ActiveDate = activeDate;
        }
    }
}
