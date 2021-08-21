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
    public class StudentService : IStudentService
    {
        private readonly StudentDBContext _context;

        public StudentService(StudentDBContext context)
        {
            _context = context;
        }
        public async Task<Student> AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            student.StudentID = Guid.NewGuid();

            try
            {
                await _context.AddAsync(student);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message.ToString();
            }
            return student;

        }
        public bool Commit()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _context.Remove(student);
        }

        public Student GetStudentById(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            return _context.Students.FirstOrDefault(x => x.StudentID == studentId);


        }

        public IEnumerable<Student> GetStudents()
        {
            var query = from x in _context.Students
                        orderby x.Department
                        select x;
            return query;
        }

        public Student Login(Guid studentId, string FirstName)
        {
            if (studentId == Guid.Empty & FirstName == string.Empty)
            {
                throw new NotImplementedException(nameof(studentId));
            }
            return _context.Students.FirstOrDefault(x => x.StudentID == studentId && x.FirstName == FirstName);
        }

        public Student UpdateStudent(Student updatedStudent)
        {
            if (updatedStudent == null)
            {
                throw new ArgumentNullException(nameof(updatedStudent));
            }
            var entity = _context.Students.Attach(updatedStudent);
            entity.State =EntityState.Modified;
            return updatedStudent;
        }
    }
}
