using BCrud.Domain.Dtos;
using BCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Domain.Repositories
{
    public interface ISyllabusRepository
    {
        Guid AddSyllabus(SyllabusDto dto);
        void Update(SyllabusDto dto);
        void Delete(Guid id);
        SyllabusDto FindById(Guid id);
        IEnumerable<SyllabusDto> GetAll();
    }
}
