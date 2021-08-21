using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs_Tutorial.Data;
using APIs_Tutorial.Entities;
using APIs_Tutorial.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIs_Tutorial.Services.StudentServices
{
    public class ExamServices : IExamService

    {
        private readonly StudentDBContext _context;

        public ExamServices(StudentDBContext context)
        {
            _context = context;
        }
        public async Task<ExamDetail> AddExamDetails(ExamDetail examDetail)
        {
            if (examDetail == null)
            {
                throw new ArgumentNullException(nameof(examDetail));
            }
            examDetail.DateCreated = DateTime.Now;

            try
            {
                await _context.AddAsync(examDetail);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message.ToString();
            }
            return examDetail;

        }

        public IEnumerable<ExamDetail> GetExamDetails()
        {
            var query = from x in _context.ExamDetails
                        orderby x.DateCreated
                        select x;
            return query;
        }

        public ExamDetail GetExamDetailsById(string studentId)
        {
            if (studentId == string.Empty)
            {
                throw new NotImplementedException(nameof(studentId));
            }
            return _context.ExamDetails.FirstOrDefault(x => x.StudentID == studentId);
        }
        public bool Commit()
        {
            return (_context.SaveChanges() >= 0);
        }

        public ExamDetail UpdateExamDetails(ExamDetail updatedDetail)
        {
            if (updatedDetail == null)
            {
                throw new NotImplementedException(nameof(updatedDetail));
            }
            var entity = _context.ExamDetails.Attach(updatedDetail);
            entity.State = EntityState.Modified;
            return updatedDetail;

        }
    }
}
