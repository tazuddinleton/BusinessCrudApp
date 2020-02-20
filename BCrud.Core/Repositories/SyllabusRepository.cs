using BCrud.Domain.Dtos;
using BCrud.Domain.Entities;
using BCrud.Domain.Repositories;
using BCrud.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Syllabus FindById(Guid id)
        {
            return _context.Syllabi.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<SyllabusDto> GetAll()
        {
            return _context.Syllabi
                .Select(x=> 
                    new SyllabusDto(x.Id,
                x.Name,
                x.TradeId,
                x.TradeLevelId,
                x.Languages,
                x.SyllabusUrl,
                x.TestPlanUrl,
                x.DevelopmentOfficer,
                x.Manager,
                x.ActiveDate
                ))
                .ToList();
        }
    }
}
