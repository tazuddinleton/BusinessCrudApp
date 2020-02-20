using BCrud.Domain.Dtos;
using BCrud.Domain.Entities;
using BCrud.Domain.Repositories;
using BCrud.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BCrud.Core.Repositories
{
    public class SyllabusRepository : ISyllabusRepository
    {
        private readonly DatabaseContext _context;

        public SyllabusRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Guid AddSyllabus(SyllabusDto dto)
        {

            var syllabus = new Syllabus(dto.Id, 
                dto.Name, 
                dto.TradeId, 
                dto.TradeLevelId, 
                dto.Languages, 
                dto.SyllabusUrl, 
                dto.TestPlanUrl,
                dto.DevelopmentOfficer, 
                dto.Manager, 
                dto.ActiveDate);
                
            _context.Syllabi.Add(syllabus);
            _context.SaveChanges();
            return syllabus.Id;
        }

        public void Update(SyllabusDto dto)
        {

            var syllabus = new Syllabus(dto.Id,
                 dto.Name,
                 dto.TradeId,
                 dto.TradeLevelId,
                 dto.Languages,
                 dto.SyllabusUrl,
                 dto.TestPlanUrl,
                 dto.DevelopmentOfficer,
                 dto.Manager,
                 dto.ActiveDate);
            _context.Syllabi.Update(syllabus);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _context.Syllabi.FirstOrDefault(x => x.Id == id);
            if (entity != null)
                _context.Syllabi.Remove(entity);
            _context.SaveChanges();
        }

        public SyllabusDto FindById(Guid id)
        {


            var syllabus =
            (from s in _context.Syllabi.Where(x=> x.Id == id)
             join t in _context.Trades on s.TradeId equals t.Id
             join tv in _context.TradeLevels on s.TradeLevelId equals tv.Id

             select new SyllabusDto(s.Id,
                s.Name,
                s.TradeId,
                t.Title,
                s.TradeLevelId,
                tv.Title,
                s.Languages,
                s.SyllabusUrl,
                s.TestPlanUrl,
                s.DevelopmentOfficer,
                s.Manager,
                s.ActiveDate
                )).SingleOrDefault();

            return syllabus;
        }

        public IEnumerable<SyllabusDto> GetAll()
        {
            return
            (from s in _context.Syllabi
             join t in _context.Trades on s.TradeId equals t.Id
             join tv in _context.TradeLevels on s.TradeLevelId equals tv.Id

             select new SyllabusDto(s.Id,
                s.Name,
                s.TradeId,
                t.Title,
                s.TradeLevelId,
                tv.Title,
                s.Languages,
                s.SyllabusUrl,
                s.TestPlanUrl,
                s.DevelopmentOfficer,
                s.Manager,
                s.ActiveDate
                )).ToList();

        }
    }
}
